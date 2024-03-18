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
    public GameObject VC;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            VC.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            VC.SetActive(false);
        }
    }
}
