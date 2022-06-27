using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //mendapatkan Text UI komponen pada gameObject
        scoreTextUI = GetComponent<Text>();        
    }

    //fungsi mengupdate score
    void UpdateScore()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }
}
