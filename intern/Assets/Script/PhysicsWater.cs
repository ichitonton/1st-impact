using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWater : MonoBehaviour
{
    public GameObject water;
    Rigidbody2D rigid;
    public float buoyancy; //浮力
    public float moveSpeed = 1.0f;
    public float addForceDown = 10.0f;
    float distansFromDefault;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //distansFromDefault = defaultPositionX - gameObject.GetComponent<Transform>().position.x;
        //rigid.velocityX = distansFromDefault * 0.1f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //水と接触していたら
        if (collision.gameObject == water)
        {
            //Debug.Log("tatch water");

            rigid.gravityScale = 1.0f;

            //水抵抗
            if (rigid.velocity.y < 0)
            {
                rigid.velocity *= 0.98f;
            }
            else if (rigid.velocity.y > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.98f, rigid.velocity.y * 1.02f);

            }

            //上向きに加速度を加える(浮力)
            Vector2 force = new Vector2(0.0f, buoyancy);

            rigid.AddForce(force, ForceMode2D.Force);

        }
        else
        {
            rigid.gravityScale = 2.5f;
        }
    }

    public void Sink(float sinkForce)
    {
        //下向きに加速度を加える
        Vector2 force = new Vector2(0.0f, -sinkForce);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
