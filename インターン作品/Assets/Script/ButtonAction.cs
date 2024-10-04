using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public Fade fade;
    string sceneName = "NULL";
    private GameObject scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText"); // 今回追加箇所    
    }
    void Update()
    {
        if (fade.GetGoNextScene())
        {
            //スコア保存
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                PlayerPrefs.SetInt("SCORE", scoreText.GetComponent<ScoreManager>().score);
                PlayerPrefs.Save();
            }
            //シーン遷移
            if (sceneName != "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void changeScene(string scene)
    {
        if (!fade.IsFade())
        {
            fade.IsFadeOut();
            sceneName = scene;
            //SceneManager.LoadScene(sceneName);//sceneを呼び出します
        }
    }
    public void end()
    {
        if (!fade.IsFade())
        {
            Debug.Log("Press the end button");

            UnityEditor.EditorApplication.isPlaying = false;

            //Application.Quit();
        }
    }

    public void addScore()
    {
        scoreText.GetComponent<ScoreManager>().score += 1;
    }
}
