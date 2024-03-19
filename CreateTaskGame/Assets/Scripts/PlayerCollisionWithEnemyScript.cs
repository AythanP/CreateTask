/*Name: Aythan Pao
 * Date: 1-16-24
 * Desc: Script that teleports the player to a location when they hit an enemy, meant to be attached to the player object.
 * This script is the same as OCRS but more generally applicable
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithEnemyScript : MonoBehaviour
{
    // enemy gameobject
    [HideInInspector]
    public GameObject enemy;
    // respawn position
    public GameObject respawn;
    // player rigidbody
    private Rigidbody2D playerRB;
    // player gameobject
    public GameObject player;
    // player controller
    private PlayerController PC;
    // fade animation for the artifact
    public Animator transition;
    // how long the wait between transitions are
    private float time = 1f;
    // particles to spawn upon death
    public GameObject particles;
    // to control if the particles can play or not
    private ParticleSystem effects;
    [HideInInspector]
    // to reset every single game object other than the player
    public bool reset;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        PC = player.GetComponent<PlayerController>();
        effects = particles.GetComponent<ParticleSystem>();
        reset = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.gameObject;
        if (enemy.CompareTag("Enemy") || enemy.CompareTag("SpikesObject"))
        {
            StartCoroutine(death());
            reset = true;
        }
    }

    IEnumerator death()
    {
        //reset = false;
        transition.SetTrigger("Start");
        PC.enabled = false;
        playerRB.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(time);
        player.transform.position = respawn.transform.position;
        particles.transform.position = respawn.transform.position;
        transition.SetTrigger("End");
        effects.Play();
        //yield return new WaitForSeconds(time);
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        PC.enabled = true;
        reset = false;
    }
}
