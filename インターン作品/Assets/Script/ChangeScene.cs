using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void change_button(string sceneName)
    {
        if (sceneName == "esc")
        {
            UnityEngine.Application.Quit();
        }
        else
        {
            Debug.Log("Press the button");
            SceneManager.LoadScene(sceneName);//scene‚ğŒÄ‚Ño‚µ‚Ü‚·
        }
    }
}
