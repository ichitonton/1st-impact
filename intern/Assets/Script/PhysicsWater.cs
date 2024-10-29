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
    private float maxSoundSpeed = 10.0f;
    private float minSoundSpeed = 2.5f;
    public bool isEffect = false;
    public ParticleSystem particle;

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
    private void SetVolume()
    {
        float speedY = rigid.velocityY;

        //ê≥ãKâª
        if(speedY < 0)
        {
            speedY *= -1;
        }

        if(speedY < minSoundSpeed)
        {
            waterSound.volume = 0.0f;
        }
        else if(speedY > maxSoundSpeed)
        {
            waterSound.volume = 1.0f;
           // particle.startSpeed = (maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 6.0f;
            particle.startSpeed = speedY;
            particle.GetComponent<Transform>().position = rigid.position;
            //particle.GetComponent<Transform>().localScale = new Vector3((maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 0.35f, (maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 0.35f, 1.0f);
            particle.Play();
        }
        else
        {
            waterSound.volume = (speedY - minSoundSpeed) / (maxSoundSpeed - minSoundSpeed);
            //particle.startSpeed = (maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 6.0f;
            particle.startSpeed = speedY;
            particle.GetComponent<Transform>().position = rigid.position;
            //particle.GetComponent<Transform>().localScale = new Vector3((maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 0.35f, (maxSoundSpeed - minSoundSpeed) / maxSoundSpeed * 0.35f, 1.0f);
            particle.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSoundWater)
        {
            if (collision.gameObject == water)
            {
                if (waterSound != null)
                {
                    SetVolume();
                    waterSound.PlayOneShot(waterInClip);
                }
                else
                {
                    Debug.Log("audiosource=null");
                }
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

            if (isSoundWater)
            {
                SetVolume();
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
    }

    public void Sink(float sinkForce)
    {
        //â∫å¸Ç´Ç…â¡ë¨ìxÇâ¡Ç¶ÇÈ
        Vector2 force = new Vector2(0.0f, -sinkForce);
        rigid.AddForce(force, ForceMode2D.Force);
    }
}
