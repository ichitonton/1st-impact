using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWater : MonoBehaviour
{
    public GameObject water;
    Rigidbody2D rigid;
    public float buoyancy; //•‚—Í
    public float moveSpeed = 1.0f;
    public float addForceDown = 10.0f;
    float distansFromDefault;
    public float upForceMagnification = 1.0f;
    public float douwnForceMagnification = 1.0f;
    public float inWaterGravityScale = 1.0f;
    public float outWaterGravityScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //distansFromDefault = defaultPositionX - gameObject.GetComponent<Transform>().position.x;
        //rigid.velocityX = distansFromDefault * 0.1f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //…‚ÆÚG‚µ‚Ä‚¢‚½‚ç
        if (collision.gameObject == water)
        {
            //Debug.Log("tatch water");

            rigid.gravityScale = inWaterGravityScale;

            //…’ïR
            if (rigid.velocity.y < 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.99f, rigid.velocity.y * douwnForceMagnification);
            }
            else if (rigid.velocity.y > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.99f, rigid.velocity.y * upForceMagnification);

            }

            //ãŒü‚«‚É‰Á‘¬“x‚ğ‰Á‚¦‚é(•‚—Í)
            Vector2 force = new Vector2(0.0f, buoyancy);

            rigid.AddForce(force, ForceMode2D.Force);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //…‚ÆÚG‚µ‚Ä‚¢‚½‚ç
        if (collision.gameObject == water)
        {
            rigid.gravityScale = outWaterGravityScale;
            Debug.Log("out water" + rigid.gravityScale);
        }
    }

    public void Sink(float sinkForce)
    {
        //‰ºŒü‚«‚É‰Á‘¬“x‚ğ‰Á‚¦‚é
        Vector2 force = new Vector2(0.0f, -sinkForce);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
