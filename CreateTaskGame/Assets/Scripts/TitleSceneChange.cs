/*Landon Hilton
 * 11/17/2023
 * Description: Function to be used by menu buttons that loads the specified scene when clicked
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    private bool keyPressed = false;
    public void Update()
    {
        if(Input.anyKey && !keyPressed)
        {
            keyPressed = true;
            PlayScene();
        }
    }
    public void PlayScene()
    {
        SceneManager.LoadScene("AythanTestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
