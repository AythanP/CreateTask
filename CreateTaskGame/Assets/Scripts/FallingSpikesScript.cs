/*Name: Aythan Pao
 * Date: 1-10-24
 * Desc: Script that basically switches an object's gravity on and off. Unlike FTS, this should be attatched to the child trigger, not the parent object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikesScript : MonoBehaviour
{
    // amount of time before an the tiles falls
    public float deathTime = 1;
    public Rigidbody2D RB;
    // to reset the tiles
    public OnCollisionResetScript CRS;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        RB.bodyType = RigidbodyType2D.Static;
        originalPos = RB.transform.position;
        //print(originalPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Player has entered the trigger");
        CRS.reset = false;
        StartCoroutine(fall());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Player has entered the trigger");
        CRS.reset = false;
        StartCoroutine(fall());
    }

    private void Update()
    {
        if (CRS != null && CRS.reset == true)
        {
            RB.transform.position = originalPos;
            RB.bodyType = RigidbodyType2D.Static;
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(deathTime);
        RB.bodyType = RigidbodyType2D.Dynamic;
        print("Spike is falling");
    }
}
