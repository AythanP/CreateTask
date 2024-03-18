/*Name: Aythan Pao
 * Date: 1-19-24
 * Desc: Script meant to be attached to a spike that causes the gameobject to disable itself when it stops falling
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDisappearScript : MonoBehaviour
{
    // gameobject being collided with
    [HideInInspector]
    public GameObject gameO;
    // gameobject of the spike that the script is attached to
    public GameObject mySpike;
    // particles to spawn upon dissappearance
    public GameObject particles;
    // sfx for when the spike is broken
    public AudioClip soundEffect;
    private AudioSource myAudio;
    // to prevent the sound from playing twice
    [HideInInspector]
    public bool hasBroken;
    // to allow the sfx to actually play (set the time at least a millisecond longer than the original audio)
    private float time = 0.260f;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        hasBroken = false;
        mySpike.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameO = collision.gameObject;
        //print(gameO);
        // if gameO's not null, that means the spike hit something and won't disappear prematurely
        if (gameO != null && (gameO.CompareTag("Player") || gameO.CompareTag("Enemy")) || gameO.CompareTag("Ground") || gameO.CompareTag("SpikesObject"))
        {
            StartCoroutine(play());
        }
    }

    IEnumerator play()
    {
        GameObject PS = Instantiate(particles, transform.position, Quaternion.identity);
        PS.transform.position = transform.position;
        if (hasBroken == false)
        {
            myAudio.PlayOneShot(soundEffect);
            hasBroken = true;
            yield return new WaitForSeconds(time);
        }
        mySpike.SetActive(false);
        Destroy(PS, PS.GetComponent<ParticleSystem>().main.duration);

    }
}
