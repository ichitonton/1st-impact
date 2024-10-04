using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public Fade fade;
    string sceneName;
    private GameObject scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText"); // ç°âÒí«â¡â”èä    
    }
    void Update()
    {
        if (fade.GetGoNextScene())
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void changeScene(string scene)
    {
        if (!fade.IsFade())
        {
            fade.IsFadeOut();
            sceneName = scene;
            //SceneManager.LoadScene(sceneName);//sceneÇåƒÇ—èoÇµÇ‹Ç∑
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
