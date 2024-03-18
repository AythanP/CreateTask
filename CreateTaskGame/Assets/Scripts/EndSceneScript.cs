/* Name: Aythan Pao
 * Date: 2-21-24
 * Desc: Script that loads the end scene
 */

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class EndSceneScript : MonoBehaviour
{
    public string Scene;
    // if the player runs into the trigger, the game ends
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
