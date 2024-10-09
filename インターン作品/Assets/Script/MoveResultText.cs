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
    public float moveSpeed;//ゴール判定と同時に流れてくる→
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
        //ゴールしたら

        if (!isDecisionResult)
        {
            if (goal.GetIsGoal())
            {
                //結果が決まった
                isDecisionResult = true;
                //タイマーストップ
                timer.StopTimer();

                resultText.text = successMessage + "\n";
                resultText.text += "残り時間：" + timer.GetTime().ToString("F3");
            }

            //時間内にゴールできなかったら
            if (!goal.GetIsGoal() && timer.GetTime() <= 0)
            {
                //結果が決まった
                isDecisionResult = true;
                //タイマーストップ
                timer.StopTimer();

                resultText.text = failureMessage;
            }
        }

        //結果が決まったら
        if (isDecisionResult)
        {
            //テキストを動かす
            trans.position = new Vector3(trans.position.x + moveSpeed, trans.position.y, trans.position.z);

            if(trans.position.x >= stopPositionX)
            {
                trans.position = new Vector3(stopPositionX, trans.position.y, trans.position.z);
            }
        }

    }
}
