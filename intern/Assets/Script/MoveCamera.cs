using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Transform goal;
    public Vector2 offset;
    private Transform cameraTrans;
    private float goalPositionX;
    private bool gameStart = false;
    public int nowFrameRate = 60;
    public float surveyScond = 4.0f;
    private float firstCameraToGoalDis;
    private int countFrame;
    public Fade fade;
    private bool stopCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        goalPositionX = goal.position.x;
        cameraTrans = gameObject.GetComponent<Transform>();
        firstCameraToGoalDis = goalPositionX - (player.GetComponent<Transform>().position.x + offset.x);
        Vector3 cameraPosition = new Vector3(goalPositionX, offset.y, -10.0f);
        cameraTrans.position = cameraPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!stopCamera)
        {
            if (gameStart)
            {
                Vector3 cameraPosition = new Vector3(player.GetComponent<Transform>().position.x + offset.x, offset.y, -10.0f);
                cameraTrans.position = cameraPosition;
            }
        }
    }

    private void Update()
    {
        if (!fade.IsFadeIn())
        {
            if (!gameStart)
            {
                countFrame += 1;
                if(countFrame <= nowFrameRate)
                { }
                else if (countFrame <= surveyScond * nowFrameRate + nowFrameRate)
                {
                    cameraTrans.position -= new Vector3(firstCameraToGoalDis / (surveyScond * nowFrameRate), 0.0f, 0.0f);
                }
                else if (countFrame >= surveyScond * nowFrameRate + nowFrameRate*1.2f)
                {
                    gameStart = true;
                }
            }
        }
    }

    public bool GetGameStart()
    {
        return gameStart;
    }
    public void CameraStop()
    {
        stopCamera = true;
        Debug.Log("stopcamera");
    }
}

