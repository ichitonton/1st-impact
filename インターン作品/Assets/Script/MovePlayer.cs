using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(moveSpeed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.velocityX <= 1.0)
        {
            rigid.AddForce(new Vector2(3.0f, 0.0f), ForceMode2D.Force);
        }


    }
}
