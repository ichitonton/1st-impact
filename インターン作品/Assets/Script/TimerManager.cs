using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text timeText;
    public float countDownMax = 60.0f;
    private float time = 0.0f;
    private int sec = 0;
    private int msec = 0;
    private bool isCountTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = "0";
        time = countDownMax;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountTimer)
        {
            time -= Time.deltaTime;//���t���[���̎��Ԃ����Z
        }
        sec = (int)time;//�b
        msec = (int)(time * 1000 % 1000);


        //timeText.text = timeMax.ToString();
        if(sec >= 100)//sec��3���ȏ�
        {
            timeText.text = sec.ToString();
        }
        else if(sec >= 10)//sec��2��
        {
            timeText.text = "0" + sec.ToString();
        }
        else if(sec >= 1)//sec��1��
        {
            timeText.text = "00" + sec.ToString();

        }
        else if(sec < 1)//sec��1����(0)
        {
            timeText.text = "000";
        }

        timeText.text += ":";

        if (msec >= 100)//msec��3���ȏ�
        {
            timeText.text += msec.ToString();
        }
        else if (msec >= 10)//msec��2��
        {
            timeText.text += "0" + msec.ToString();
        }
        else if (msec >= 1)//msec��1��
        {
            timeText.text += "00" + msec.ToString();

        }
        else if (msec < 1)//msec��1����(0)
        {
            timeText.text += "000";
        }
    }
    public float GetTime()
    {
        return time;
    }

    public void StopTimer()
    {
        isCountTimer = true;
    }
}
