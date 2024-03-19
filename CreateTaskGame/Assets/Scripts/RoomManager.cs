/*Name: Aythan Pao
 * Date: 12-1-23
 * Desc: Camera that uses cinemachine and room colliders
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source: https://www.youtube.com/watch?v=yaQlRvHgIvE 

public class RoomManager : MonoBehaviour
{
    // the virtual camera assigned to a specific section
    public GameObject VC;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player is in the section, the camera turns on
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            VC.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if the player exists the section, the camera turns off
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            VC.SetActive(false);
        }
    }
}
