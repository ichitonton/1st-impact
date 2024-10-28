using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PhysicsWater : MonoBehaviour
{
    public GameObject water;
    Rigidbody2D rigid;
    public float buoyancy; //ïÇóÕ
    public float moveSpeed = 1.0f;
    public float addForceDown = 10.0f;
    float distansFromDefault;
    public float upForceMagnification = 1.0f;
    public float douwnForceMagnification = 1.0f;
    public float inWaterGravityScale = 1.0f;
    public float outWaterGravityScale = 1.0f;
    public bool isSoundWater = false;
    private AudioSource waterSound;
    public AudioClip waterInClip;
    public AudioClip waterOutClip;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        waterSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //distansFromDefault = defaultPositionX - gameObject.GetComponent<Transform>().position.x;
        //rigid.velocityX = distansFromDefault * 0.1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == water)
        {
            if (waterSound != null)
            {
                waterSound.PlayOneShot(waterInClip);
            }
            else
            {
                Debug.Log("audiosource=null");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //êÖÇ∆ê⁄êGÇµÇƒÇ¢ÇΩÇÁ
        if (collision.gameObject == water)
        {
            //Debug.Log("tatch water");

            rigid.gravityScale = inWaterGravityScale;

            //êÖíÔçR
            if (rigid.velocity.y < 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.99f, rigid.velocity.y * douwnForceMagnification);
            }
            else if (rigid.velocity.y > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x * 0.99f, rigid.velocity.y * upForceMagnification);

            }

            //è„å¸Ç´Ç…â¡ë¨ìxÇâ¡Ç¶ÇÈ(ïÇóÕ)
            Vector2 force = new Vector2(0.0f, buoyancy);

            rigid.AddForce(force, ForceMode2D.Force);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //êÖÇ∆ê⁄êGÇµÇƒÇ¢ÇΩÇÁ
        if (collision.gameObject == water)
        {
            rigid.gravityScale = outWaterGravityScale;
            Debug.Log("out water" + rigid.gravityScale);

            if (waterSound != null)
            {
                waterSound.PlayOneShot(waterOutClip);
            }
            else
            {
                Debug.Log("audiosource=null");
            }
        }
    }

    public void Sink(float sinkForce)
    {
        //â∫å¸Ç´Ç…â¡ë¨ìxÇâ¡Ç¶ÇÈ
        Vector2 force = new Vector2(0.0f, -sinkForce);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
