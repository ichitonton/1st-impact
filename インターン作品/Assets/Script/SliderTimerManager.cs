using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimerManager : MonoBehaviour
{
    private Slider timeSlider;
    public float countDownMax = 60.0f;
    private float time = 0.0f;
    private int sec = 0;
    private int msec = 0;
    private bool isCountTimer = false;//�^�C�}�[�𓮂������ǂ���
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
        timeSlider.value = time;

        if (!isCountTimer)
        {
            time -= Time.deltaTime;//���t���[���̎��Ԃ����Z
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

    //�^�C�}�[�X�g�b�v
    public void StopTimer()
    {
        isCountTimer = true;
    }
}
