using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Color color;
    bool fadeIn = true;
    bool fadeOut = false;
    bool goNextScene = false;
    int alpha = 255;
    int fadeSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("set color");
        color = gameObject.GetComponent<Image>().color;
        color = new Color32(255, 255, 255, 255);
        alpha = 255;
        fadeIn = true;
        fadeOut = false;
        goNextScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            Debug.Log("fadein now");
            gameObject.GetComponent<Image>().color -= new Color32(0, 0, 0, (byte)fadeSpeed);
            alpha -= fadeSpeed;
            //フェードイン終了
            if (alpha <= 0)
            {
                fadeIn = false;
            }
        }
        if (fadeOut)
        {
            Debug.Log("fadeout now");
            gameObject.GetComponent<Image>().color += new Color32(0, 0, 0, (byte)fadeSpeed);
            alpha += fadeSpeed;

            //フェードアウト終了
            if (alpha >= 255)
            {
                fadeOut = false;

                //シーン移行
                goNextScene = true;
            }
        }
        
    }

    public void IsFadeOut()
    {
        fadeOut = true;
    }
    public bool IsFade()
    {
        return fadeIn || fadeOut;
    }
    public bool GetGoNextScene()
    {
        return goNextScene;
    }
}
