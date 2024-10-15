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
    private bool isCountTimer = false;//�^�C�}�[�𓮂������ǂ���
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
        sec = (int)time;//�b
        msec = (int)(time * 1000 % 1000);

        SetTimeText(sec, msec);
        if (!isCountTimer)
        {
            time -= Time.deltaTime;//���t���[���̎��Ԃ����Z
        }
    }

    private void SetTimeText(int s, int ms)
    {
        //timeText.text = timeMax.ToString();
        if (s >= 100)//s��3���ȏ�
        {
            timeText.text = s.ToString();
        }
        else if (s >= 10)//s��2��
        {
            timeText.text = "0" + s.ToString();
        }
        else if (s >= 1)//s��1��
        {
            timeText.text = "00" + s.ToString();

        }
        else if (s < 1)//s��1����(0)
        {
            timeText.text = "000";
        }

        timeText.text += ":";

        if (ms >= 100)//ms��3���ȏ�
        {
            timeText.text += ms.ToString();
        }
        else if (ms >= 10)//ms��2��
        {
            timeText.text += "0" + ms.ToString();
        }
        else if (ms >= 1)//ms��1��
        {
            timeText.text += "00" + ms.ToString();

        }
        else if (ms < 1)//ms��1����(0)
        {
            timeText.text += "000";
        }
    }

    public float GetTime()
    {
        return time;
    }

    //�^�C�}�[�X�g�b�v
    public void StopTimer()
    {
        isCountTimer = true;
    }
}
