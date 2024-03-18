/*Name: Aythan Pao
 * Date: 1-10-24
 * Desc: Script that basically switches an object's gravity on and off. Unlike the original (FTS), this should be attatched to the child trigger, not the parent object. Unlike its previous version (MFSS), this should be attatched to spikes facing up or spikes that don't move
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod2FallingSpikesScript : MonoBehaviour
{
    // amount of time before an the tiles falls
    public float deathTime = 1;
    // rigidbody of the spike, aka the parent object
    public GameObject spike;
    // rigidbody of the spike
    public Rigidbody2D spikeRB;
    // to reset the spikes
    public PlayerCollisionWithEnemyScript PCES;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        spikeRB.bodyType = RigidbodyType2D.Static;
        originalPos = spikeRB.transform.position;
        //print(originalPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Player has entered the trigger");
        //CRS.reset = false;
        StartCoroutine(fall());

    }

    private void Update()
    {
        if (PCES != null && PCES.reset == true)
        {
            StopAllCoroutines();
            //spike.SetActive(true);
            spikeRB.bodyType = RigidbodyType2D.Static;
            spikeRB.transform.position = originalPos;
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(deathTime);
        spikeRB.bodyType = RigidbodyType2D.Dynamic;
        
    }
}
