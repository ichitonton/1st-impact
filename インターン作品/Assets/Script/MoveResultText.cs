using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveResultText : MonoBehaviour
{
    private Transform trans;
    public Text resultText;
    public GoalManager goal;
    public TimerManager timer;
    public float moveSpeed;//�S�[������Ɠ����ɗ���Ă��遨
    private bool isDecisionResult = false;
    public string successMessage;
    public string failureMessage;
    public float stopPositionX;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
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
                resultText.text += "�c�莞�ԁF" + timer.GetTime().ToString("F3");
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
