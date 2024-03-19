/*Name: Aythan Pao
 * Date: 1-23-24
 * Desc: Script that lowers music volume in certain areas
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSecretScript : MonoBehaviour
{
    // the source of in-game music
    public AudioSource global;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            global.volume = 0.25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        global.volume = 1;
    }
}
