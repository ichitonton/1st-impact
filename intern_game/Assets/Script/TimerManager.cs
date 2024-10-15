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
    private bool isCountTimer = false;//タイマーを動かすかどうか
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = "0";
        time = countDownMax;

    }

    void Update()
    {
        if(Time.timeScale == 0)
        {

            time = countDownMax;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        sec = (int)time;//秒
        msec = (int)(time * 1000 % 1000);

        SetTimeText(sec, msec);
        if (!isCountTimer)
        {
            time -= Time.deltaTime;//毎フレームの時間を減算
        }
    }

    private void SetTimeText(int s, int ms)
    {
        //timeText.text = timeMax.ToString();
        if (s >= 100)//sが3桁以上
        {
            timeText.text = s.ToString();
        }
        else if (s >= 10)//sが2桁
        {
            timeText.text = "0" + s.ToString();
        }
        else if (s >= 1)//sが1桁
        {
            timeText.text = "00" + s.ToString();

        }
        else if (s < 1)//sが1未満(0)
        {
            timeText.text = "000";
        }

        timeText.text += ":";

        if (ms >= 100)//msが3桁以上
        {
            timeText.text += ms.ToString();
        }
        else if (ms >= 10)//msが2桁
        {
            timeText.text += "0" + ms.ToString();
        }
        else if (ms >= 1)//msが1桁
        {
            timeText.text += "00" + ms.ToString();

        }
        else if (ms < 1)//msが1未満(0)
        {
            timeText.text += "000";
        }
    }

    public float GetTime()
    {
        return time;
    }

    //タイマーストップ
    public void StopTimer()
    {
        isCountTimer = true;
    }
}
