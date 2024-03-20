/* Author: Aythan Pao
 * Date: 3-14-24
 * Desc: Add to the TMP Pro text object to display the high score
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    TMP_Text myText;
    GameManager gameManager;
    List<int> scores;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        scores = gameManager.scores;
        scores.Add(GameManager.score);
        myText = GetComponent<TMP_Text>();
        ChangeText();
        GameManager.ScoreUpdate.AddListener(ChangeText);
        
    }

    private void ChangeText()
    {
        myText.text = "High Score: " + highscore(scores);
        for (int i = 0; i < scores.Count; i++)
        {
            print(scores[i]);
        }

    }
    
    // function to determine the highest score from a list of integers
    int highscore(List<int> scores)
    {
        int max = 0;
        int length = scores.Count;
        for (int i = 0; i < length; i++)
        {
            if (scores[i] > max)
            {
                max = scores[i];
            }
        }
        return max;
    }
}
