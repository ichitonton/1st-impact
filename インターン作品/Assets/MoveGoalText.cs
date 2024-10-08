using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGoalText : MonoBehaviour
{
    private RectTransform trans;
    private Text text;
    public GoalManager goal;
    public TimerManager timer;
    public float moveSpeed;//ゴール判定と同時に流れてくる→
    private bool isDecisionResult = false;
    public string successMessage;
    public string failureMessage;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //
        if (goal.GetIsGoal())
        {
            isDecisionResult = true;
            //
            timer.StopTimer();

            text.text = successMessage + "\n";
            text.text += "残り時間："　+ timer.GetTime().ToString();
        }

        //
        if (!goal.GetIsGoal() && timer.GetTime() <= 0)
        {
            isDecisionResult = true;
            //
            timer.StopTimer();

            text.text = failureMessage;
        }

        if (isDecisionResult)
        {
            //
            trans.position = new Vector3(trans.position.x + moveSpeed, trans.position.y, trans.position.z);

        }

    }
}
