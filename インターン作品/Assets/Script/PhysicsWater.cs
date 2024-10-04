using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWater : MonoBehaviour
{
    public GameObject water;
    Rigidbody2D rigid;
    public float buoyancy; //浮力
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //水と接触していたら
        if (collision.gameObject == water)
        {
            rigid.gravityScale = 0.5f;
            //Debug.Log("tatch water");
            //水抵抗
            rigid.velocity *= 0.98f;

            //上向きに加速度を加える
            Vector2 force = new Vector2(0.0f, buoyancy);

            rigid.AddForce(force, ForceMode2D.Force);

        }
        else
        {
            rigid.gravityScale = 2.0f;
        }
    }

    public void Sink()
    {
        //下向きに加速度を加える
        Vector2 force = new Vector2(0.0f, -3.5f);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
