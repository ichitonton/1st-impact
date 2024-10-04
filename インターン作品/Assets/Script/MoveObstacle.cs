using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    Rigidbody2D rigid;
    public float moveForce = 5.0f;
    public float moveVelocity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //rigid.AddForceX(-moveForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocityX = -moveVelocity;
    }
}
