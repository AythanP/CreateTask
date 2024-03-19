/*Name: Aythan Pao
 * Date: 1-22-24
 * Desc: Script meant to be set the respawn point when something collides with the trigger this script is attached to
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawnScript : MonoBehaviour
{
    // respawn point
    public GameObject respawn;
    // player gameobject
    [HideInInspector]
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when the player collides with the trigger, their respawn point is changed to whatever is in "respawn"
        player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            player.GetComponent<PlayerCollisionWithEnemyScript>().respawn = respawn;
        }
    }
}
