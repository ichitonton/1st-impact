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
    public GameObject CountDown3;
    public GameObject CountDown2;
    public GameObject CountDown1;
    public GameObject BlockTatchPanel;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        CountDown3.SetActive(false);
        CountDown2.SetActive(false);
        CountDown1.SetActive(false);
        BlockTatchPanel.SetActive(true);
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
                if (countDownSecond > 2)
                {
                    CountDown3.SetActive(true);
                    CountDown2.SetActive(false);
                    CountDown1.SetActive(false);
                }
                else if (countDownSecond > 1)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(true);
                    CountDown1.SetActive(false);
                }
                else if (countDownSecond > 0)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(false);
                    CountDown1.SetActive(true);
                }
                else if (countDownSecond > -1)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(false);
                    CountDown1.SetActive(false);
                    text.text = "START";
                }
                else
                {
                    BlockTatchPanel.SetActive(false);
                    text.text = "";
                    Time.timeScale = 1;
                }
            }
            //text.text = countFrame.ToString();
        }
    }
}
