using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public Fade fade;
    string sceneName = "NULL";
    private GameObject scoreText;
    private AudioSource audioSource = null;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText"); // ����ǉ��ӏ�    
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (fade.GetGoNextScene())
        {
            //�X�R�A�ۑ�
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                PlayerPrefs.SetInt("SCORE", scoreText.GetComponent<ScoreManager>().score);
                PlayerPrefs.Save();
            }
            //�V�[���J��
            if (sceneName != "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void ChangeScene(string scene)
    {
        if (!fade.IsFade())
        {
            fade.IsFadeOut();
            sceneName = scene;
            //SceneManager.LoadScene(sceneName);//scene���Ăяo���܂�
        }
    }
    public void End()
    {
        if (!fade.IsFade())
        {
            Debug.Log("Press the end button");

            //UnityEditor.EditorApplication.isPlaying = false;

            Application.Quit();
        }
    }
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }

    public void AddScore()
    {
        scoreText.GetComponent<ScoreManager>().score += 1;
    }
    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }

}
