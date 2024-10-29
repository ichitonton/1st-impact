using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour
{
    private Text text;
    private bool isCountDown = false;
    public float countDownSecond;
    public float nowFrameParSecond = 60;
    private float countFrame = 0;
    public GameObject CountDown3;
    public GameObject CountDown2;
    public GameObject CountDown1;
    public GameObject BlockTatchPanel;
    public MoveCamera moveCamera;
    private bool endCountDown = false;
    private AudioSource audioSource = null;
    public AudioClip countDownClip;
    public AudioClip startClip;
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
        if (moveCamera.GetGameStart())
        {
            isCountDown = true;
        }
        if (endCountDown)
        {
            isCountDown = false;
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
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(countDownClip);
                    }
                    else
                    {
                        Debug.Log("audiosource=null");
                    }
                }
                else if (countDownSecond > 1)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(true);
                    CountDown1.SetActive(false);
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(countDownClip);
                    }
                    else
                    {
                        Debug.Log("audiosource=null");
                    }
                }
                else if (countDownSecond > 0)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(false);
                    CountDown1.SetActive(true);
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(countDownClip);
                    }
                    else
                    {
                        Debug.Log("audiosource=null");
                    }
                }
                else if (countDownSecond > -1)
                {
                    CountDown3.SetActive(false);
                    CountDown2.SetActive(false);
                    CountDown1.SetActive(false);
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(startClip);
                    }
                    else
                    {
                        Debug.Log("audiosource=null");
                    }
                    text.text = "START";
                }
                else
                {
                    BlockTatchPanel.SetActive(false);
                    text.text = "";
                    Time.timeScale = 1;
                    endCountDown = true;
                }
            }
            //text.text = countFrame.ToString();
        }
    }
}
