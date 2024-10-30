using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveResultText : MonoBehaviour
{
    private Transform trans;
    public Text resultText;
    public GoalManager goal;
    public SliderTimerManager timer;
    public GameObject nextSceneButton;
    public float moveSpeed;//�S�[������Ɠ����ɗ���Ă��遨
    private bool isDecisionResult = false;
    public string successMessage;
    public string failureMessage;
    public float stopPositionX;
    public string thisSceneName;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int nowFrameParSeconds = 60;
    private int frameCount = 0;
    public float stopSecondIsGoal = 1.0f;
    public MoveCamera moveCamera;
    public Rigidbody2D dack;
    public GameObject yubi;
    private AudioSource audioSource = null;
    public AudioSource BGM;
    public AudioClip goalSE;
    public AudioClip failsSE;
    private bool isMove = false;
    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        nextSceneButton.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        //�S�[��������

        if (!isDecisionResult)
        {
            if (goal.GetIsGoal())
            {
                //���ʂ����܂���
                isDecisionResult = true;
                //�^�C�}�[�X�g�b�v
                timer.StopTimer();

                resultText.text = successMessage + "\n";
                resultText.text += "Clear Time�F" + timer.GetClearTime().ToString("F3") + "\n";

                if (timer.GetGrade() == 3)
                {
                    PlayerPrefs.SetInt(thisSceneName, 4);
                    //resultText.text += "������";
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);
                }
                if (timer.GetGrade() == 2)
                {
                    if(PlayerPrefs.GetInt(thisSceneName) < 2)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 3);
                    }
                    //resultText.text += "������";
                    star1.SetActive(true);
                    star2.SetActive(true);
                }
                if (timer.GetGrade() == 1)
                {
                    if (PlayerPrefs.GetInt(thisSceneName) < 1)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 2);
                    }
                    //resultText.text += "������";
                    star1.SetActive(true);
                }
                if (timer.GetGrade() == 0)
                {
                    if (PlayerPrefs.GetInt(thisSceneName) < 0)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 1);
                    }
                    //resultText.text += "������";
                }
                //�N���A�Ȃ�
                nextSceneButton.SetActive(true);
                isGoal = true; 
                //BGM.Stop();
            }

            //���ԓ��ɃS�[���ł��Ȃ�������
            if (!goal.GetIsGoal() && timer.GetTime() <= 0)
            {
                //���ʂ����܂���
                isDecisionResult = true;
                //�^�C�}�[�X�g�b�v
                timer.StopTimer();

                resultText.text = failureMessage;
                isGoal = false;
                //BGM.Stop();
            }
        }

        //���ʂ����܂�����
        if (isDecisionResult)
        {
            moveCamera.CameraStop();
            frameCount += 1;
            dack.velocityX *= 0.9f;
            dack.velocityY *= 0.95f;
            yubi.SetActive(false);

            BGM.volume -= 0.05f ;

            if (frameCount >= nowFrameParSeconds * stopSecondIsGoal && !isMove)
            {
                BGM.Stop();
                if (isGoal)
                {
                    Debug.Log("goalSE");
                    audioSource.PlayOneShot(goalSE);
                }
                else if (!isGoal)
                { 
                    audioSource.PlayOneShot(failsSE);
                }
                isMove = true;
            }
            if(isMove)
            {
                BGM.volume = 1.0f;
                //�e�L�X�g�𓮂���
                trans.position = new Vector3(trans.position.x + moveSpeed, trans.position.y, trans.position.z);

                if (trans.position.x >= stopPositionX)
                {
                    trans.position = new Vector3(stopPositionX, trans.position.y, trans.position.z);
                }
            }
        }

    }
}
