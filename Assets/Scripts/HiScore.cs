using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public Text HighScore;

    void Start()
    {
        hiScore();
    }

    void Update()
    {
        hiScore();
    }

    void hiScore()
    {
        if (PlayerPrefs.GetString("mode") == "InfinityCircleRoller")
        {
            HighScore.text = "Hi:" + PlayerPrefs.GetInt("HighScore" + PlayerPrefs.GetInt("level")).ToString();
            GetComponent<Text>().color = Color.white;
        }
        else
        {
            HighScore.text = "Hi:0";
            GetComponent<Text>().color = Color.gray;
        }
    }
}
