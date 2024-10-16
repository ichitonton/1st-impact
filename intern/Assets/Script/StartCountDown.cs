using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour
{
    private Text text;
    public Fade fade;
    private bool isCountDown = false;
    public float countDownSecond;
    public float nowFrameParSecond = 60;
    private float countFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!fade.IsFadeIn())
        {
            isCountDown = true;
        }

        if (isCountDown)
        {
            countFrame += 1;
            if (countFrame >= nowFrameParSecond)
            {
                countFrame = 0;
                //countDownSecond -= Time.deltaTime;
                countDownSecond -= 1;//ŽžŠÔ‚ðŽ~‚ß‚Ä‚¢‚é‚½‚ß‚±‚Á‚¿‚ÅƒJƒEƒ“ƒg
                if (countDownSecond > 0)
                {
                    text.text = countDownSecond.ToString("F0");
                }
                else if (countDownSecond > -1)
                {
                    text.text = "START";
                }
                else
                {
                    text.text = "";
                    Time.timeScale = 1;
                }
            }
            //text.text = countFrame.ToString();
        }
    }
}
