using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = "0";
        score = PlayerPrefs.GetInt("SCORE");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
