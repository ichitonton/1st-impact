using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerManager : MonoBehaviour
{
    private Slider timeSlider;
    public float countDownMax = 60.0f;
    public Text timeText;
    private float time = 0.0f;
    private int sec = 0;
    private int msec = 0;
    private bool isCountTimer = false;//タイマーを動かすかどうか
    public RectTransform panelStarPoint3;
    public float timeStarPoint3 = 40.0f;
    public RectTransform panelStarPoint2;
    public float timeStarPoint2 = 30.0f;
    public RectTransform panelStarPoint1;
    public float timeStarPoint1 = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeSlider = GetComponent<Slider>();
        timeSlider.maxValue = countDownMax;
        time = countDownMax;

        Vector3 thisPosition = this.GetComponent<RectTransform>().position;
        Debug.Log(thisPosition);
        Vector3 thisPositionZero = new Vector3(
            -this.GetComponent<RectTransform>().offsetMax.x,
            thisPosition.y,
            thisPosition.z);
        float thisScaleWidth = Screen.width + this.GetComponent<RectTransform>().offsetMax.x * 2;


        Debug.Log(thisPositionZero);
        Debug.Log(Screen.width);
        //GetComponent<RectTransform>().anchoredPosition.x

        panelStarPoint3.position = new Vector3(
            thisPositionZero.x + timeStarPoint3 / countDownMax * thisScaleWidth,
            thisPositionZero.y,
            thisPositionZero.z);
        panelStarPoint2.position = new Vector3(
            thisPositionZero.x + timeStarPoint2 / countDownMax * thisScaleWidth,
            thisPositionZero.y,
            thisPositionZero.z);
        panelStarPoint1.position = new Vector3(
            thisPositionZero.x + timeStarPoint1 / countDownMax * thisScaleWidth,
            thisPositionZero.y,
            thisPositionZero.z);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            //timeSlider.value = timeSlider.maxValue;
            //time = countDownMax;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        sec = (int)time;//秒
        msec = (int)(time * 1000 % 1000);

        SetTimeText(sec, msec);

        timeSlider.value = time;

        if (!isCountTimer)
        {
            time -= Time.deltaTime;//毎フレームの時間を減算
            if (time <= timeStarPoint3)
            {
                panelStarPoint3.sizeDelta = Vector2.zero;
            }
            if (time <= timeStarPoint2)
            {
                panelStarPoint2.sizeDelta = Vector2.zero;
            }
            if (time <= timeStarPoint1)
            {
                panelStarPoint1.sizeDelta = Vector2.zero;
            }
        }
    }

    public float GetTime()
    {
        return time;
    }
    public float GetClearTime()
    {
        return countDownMax - time;
    }

    public int GetGrade()
    {
        if (time >= timeStarPoint3)
        {
            return 3;
        }
        else if (time >= timeStarPoint2)
        {
            return 2;
        }
        else if (time >= timeStarPoint1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    //タイマーストップ
    public void StopTimer()
    {
        isCountTimer = true;
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
}
