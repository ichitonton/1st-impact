using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionObstacle : MonoBehaviour
{
    Rigidbody2D rigid;
    public float moveVelocityX;//動く速さ
    public float resetPositionX;//再配置右端に設置するといい感じ
    public float outsidePositionX;//左側が画面外判定

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocityX = moveVelocityX;
        if (transform.position.x <= outsidePositionX)
        {
            transform.position = new Vector3(resetPositionX, 0.0f, 0.0f);
        }
    }
}
