using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWater : MonoBehaviour
{
    public GameObject water;
    Rigidbody2D rigid;
    public float buoyancy; //����
    public float moveSpeed = 1.0f;
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
        //���ƐڐG���Ă�����
        if (collision.gameObject == water)
        {
            //Debug.Log("tatch water");

            rigid.gravityScale = 0.5f;
            
            //����R
            rigid.velocity *= 0.98f;

            //������ɉ����x��������(����)
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
        //�������ɉ����x��������
        Vector2 force = new Vector2(0.0f, -10.0f);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
