/*Name: Aythan Pao
 * Date: 2-20-24
 * Desc: Script meant to be set the respawn point when something collides with the collider this script is attached to
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSetRespawnScript : MonoBehaviour
{
    // respawn point
    public GameObject respawn;
    // player gameobject
    [HideInInspector]
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when the player collides with the trigger, their respawn point is changed to whatever is in "respawn"
        player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            player.GetComponent<PlayerCollisionWithEnemyScript>().respawn = respawn;
        }
    }
}
