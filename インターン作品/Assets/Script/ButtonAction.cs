using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public Fade fade;
    string sceneName;
    void Update()
    {
        if (fade.GetGoNextScene())
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void changeScene(string scene)
    {
        fade.IsFadeOut();
        sceneName = scene;
        //SceneManager.LoadScene(sceneName);//sceneÇåƒÇ—èoÇµÇ‹Ç∑
    }
    public void end()
    {
        Debug.Log("Press the end button");

        UnityEditor.EditorApplication.isPlaying = false;

        //Application.Quit();
    }
}
