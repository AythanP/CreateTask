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
    //private PlayerController PC;
    // death animation for the player
    public Animator transition;
    public AnimationClip[] clip;
    // how long the wait between transitions are
    private float time;
    // particles to spawn upon death
    public GameObject particles;
    // to control if the particles can play or not
    private ParticleSystem effects;
    [HideInInspector]
    // to reset every single game object
    public bool reset;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        //PC = player.GetComponent<PlayerController>();
        effects = particles.GetComponent<ParticleSystem>();
        reset = false;
        clip = transition.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clip)
        {
            // names will have to be set on a name by name basis, so when all the clips are the same length, like now, the cases are redundant. They're just there so I can pull this code for another script if I need to
            switch (clip.name)
            {
                case "DeathAnimation-End":
                    time = clip.length;
                    break;
                case "DeathAnimation-Start":
                    time = clip.length;
                    break;
            }
        }
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
        transition.SetTrigger("Start");
        //PC.enabled = false;
        playerRB.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(time);
        player.transform.position = respawn.transform.position;
        particles.transform.position = respawn.transform.position;
        transition.SetTrigger("End");
        effects.Play();
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        reset = false;
        yield return new WaitForSeconds(time);
        //PC.enabled = true;
        transition.SetTrigger("Reset");

    }
}
