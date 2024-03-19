/*Name: Aythan Pao
 * Date: 11-24-23
 * Desc: Script that teleports the player to a location when they hit something
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fix bug where player can die twice and make it so that the respawn points change with different levels
public class OnCollisionResetScript : MonoBehaviour
{
    // position to respawn at
    public GameObject respawn;
    // particles to spawn upon death
    public GameObject particles;
    // to control if the particles can play or not
    private ParticleSystem effects;
    private GameObject GO;
    // fade animation for the artifact
    public Animator transition;
    // how long the wait between transitions are
    private float time = 0.75f;
    // player gameobject
    public Rigidbody2D player;
    // to reset falling tiles
    public bool reset;

    private void Start()
    {
        effects = particles.GetComponent<ParticleSystem>();
        effects.Stop();
        reset = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GO = collision.gameObject;
        if (collision.gameObject.CompareTag("Room"))
        {
            respawn = collision.gameObject;
        }
        if (GO.CompareTag("Player"))
        {
            StartCoroutine(death());
            reset = true;
        }
    }

    IEnumerator death()
    {
        reset = false;
        transition.SetTrigger("Start");
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(time);
        GO.transform.position = respawn.transform.position;
        particles.transform.position = respawn.transform.position;
        transition.SetTrigger("End");
        effects.Play();
        yield return new WaitForSeconds(time);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<PlayerController>().enabled = true;

    }
}
