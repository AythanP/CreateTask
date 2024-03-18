/*Name: Aythan Pao
 * Date: 11-29-23
 * Desc: Script for monument/ruin interaction and animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonumentInteractionScript : MonoBehaviour
{
    // artifact meant to spawn above the ruin/monument
    public GameObject artifact;
    // object meant to be the monument
    private Rigidbody2D monument;
    // if the player has interacted with the monument
    private bool interaction;
    // fade animation for the artifact
    public Animator transition;
    // how long the wait between transitions are
    public float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        monument = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //print(interaction);
        //print(monument.transform.position);
        Vector3 artifactPos = artifact.transform.position;
        //print(artifactPos);
        // if "e" is pressed and the player hasn't interacted with the monument, the artifact will appear. If they press "e" again, the artifact will disappear
        if (Input.GetKeyDown(KeyCode.E) && interaction == false)
        {
            artifactPos.x = monument.transform.position.x;
            artifactPos.y = monument.transform.position.y + 3;
            StopCoroutine(artifactFadeEnd());
            StartCoroutine(artifactFadeStart());
            interaction = true;
            //print(artifactPos);
            artifact.transform.position = artifactPos;
        }
        else if (Input.GetKeyDown(KeyCode.E) && interaction == true)
        {
            StopCoroutine(artifactFadeStart());
            StartCoroutine(artifactFadeEnd());
            interaction = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // when the player leaves the monument's collider and they've interacted with it, the artifact will disappear. Otherwise, if they haven't interacted with it, then the artifact will stay invisible
        if (interaction != false)
        {
            StopCoroutine(artifactFadeStart());
            StartCoroutine(artifactFadeEnd());
            interaction = false;
        }
    }

    IEnumerator artifactFadeStart()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        //print(interaction);
    }

    IEnumerator artifactFadeEnd()
    {

        transition.SetTrigger("End");
        yield return new WaitForSeconds(time);
        //print(interaction);
    }
}
