/*Name: Aythan Pao
 * Date: 1-10-24
 * Desc: Script that basically switches an object's gravity on and off. Unlike the original (FTS), this should be attatched to the child trigger, not the parent object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ModFallingSpikesScript : MonoBehaviour
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
    // sfx for when the spike is falling
    public AudioClip soundEffect;
    private AudioSource myAudio;
    // to prevent the sound from playing twice
    private bool hasFallen;
    // to reset the spike breaking sound
    public SpikeDisappearScript SDS;
    

    // Start is called before the first frame update
    void Start()
    {
        hasFallen = false;
        myAudio = GetComponent<AudioSource>();
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
            hasFallen = false;
            SDS.hasBroken = false;
            //spike.SetActive(true);
            spikeRB.bodyType = RigidbodyType2D.Static;
            spikeRB.transform.position = originalPos;
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(deathTime);
        spikeRB.bodyType = RigidbodyType2D.Dynamic;
        if (hasFallen == false)
        {
            myAudio.PlayOneShot(soundEffect);
            hasFallen = true;
        }
        
    }
}
