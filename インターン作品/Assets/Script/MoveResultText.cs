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
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        nextSceneButton.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
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
                resultText.text += "CleatTime�F" + timer.GetClearTime().ToString("F3") + "\n";

                if (timer.GetGrade() == 3)
                {
                    PlayerPrefs.SetInt(thisSceneName, 4);
                    resultText.text += "������";
                }
                if (timer.GetGrade() == 2)
                {
                    if(PlayerPrefs.GetInt(thisSceneName) < 2)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 3);
                    }
                    resultText.text += "������";
                }
                if (timer.GetGrade() == 1)
                {
                    if (PlayerPrefs.GetInt(thisSceneName) < 1)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 2);
                    }
                    resultText.text += "������";
                }
                if (timer.GetGrade() == 0)
                {
                    if (PlayerPrefs.GetInt(thisSceneName) < 0)
                    {
                        PlayerPrefs.SetInt(thisSceneName, 1);
                    }
                    resultText.text += "������";
                }
                //�N���A�Ȃ�
                nextSceneButton.SetActive(true);
            }

            //���ԓ��ɃS�[���ł��Ȃ�������
            if (!goal.GetIsGoal() && timer.GetTime() <= 0)
            {
                //���ʂ����܂���
                isDecisionResult = true;
                //�^�C�}�[�X�g�b�v
                timer.StopTimer();

                resultText.text = failureMessage;
            }
        }

        //���ʂ����܂�����
        if (isDecisionResult)
        {
            //�e�L�X�g�𓮂���
            trans.position = new Vector3(trans.position.x + moveSpeed, trans.position.y, trans.position.z);

            if(trans.position.x >= stopPositionX)
            {
                trans.position = new Vector3(stopPositionX, trans.position.y, trans.position.z);
            }
        }

    }
}
