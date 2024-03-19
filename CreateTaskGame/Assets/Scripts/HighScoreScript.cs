/* Author: Aythan Pao
 * Date: 3-14-24
 * Desc: Add to the TMP Pro text object to display the high score
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// need a trigger to signal the end of the game and figure out how to have a list with infinite size (like realloc)
// need to realloc memory when a new score is recorded and append that at the end of the list

public class HighScoreScript : MonoBehaviour
{
    TMP_Text myText;
    List<int> scores;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TMP_Text>();
        ChangeText();
        GameManager.ScoreUpdate.AddListener(ChangeText);
    }

    private void ChangeText()
    {
        myText.text = "High Score: " + GameManager.score;

    }
    
    void highscore(int []scores, int length)
    {
        int max = 0;
        length = scores.Length;
        for (int i = 0; i < length; i++)
        {
            if (scores[i] > max)
            {
                max = scores[i];
            }
        }
    }
}
