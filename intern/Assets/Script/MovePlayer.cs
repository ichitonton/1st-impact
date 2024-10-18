using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeedBegin = 1.0f;
    public float moveAngularBegin = 100.0f;
    public float addForcePower = 3.0f;
    public float addVelocityAngular = 3.0f;
   // public float sinkPowerYMax = 13.0f;
   // public float sinkPowerYAdjustment = 0.01f;
    Transform trans;
    Rigidbody2D rigid;
    public Fade fade;
    private float tapPositionY;
    private float oldTapPositionY;
    //private float sinkPowerY;
    //private float sinkPowerYDecision;
    //public Camera mainCamera;
    public SliderSink sliderSink;
    public float sinkMax;
    public float sinkMin;
    private float valueDepth;
    public float sinkPower;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(moveSpeedBegin, 0.0f);
        trans = gameObject.GetComponent<Transform>();
        rigid.angularVelocity = -moveAngularBegin;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigid.velocityX <= moveSpeedBegin)
        {
            rigid.AddForce(new Vector2(addForcePower, 0.0f), ForceMode2D.Force);
        }
        if (trans.rotation.z < 0.0f)
        {
            rigid.angularVelocity += addVelocityAngular;
        }
        if (trans.rotation.z >= 0.0f)
        {
            rigid.angularVelocity -= addVelocityAngular;
        }

        valueDepth = (sinkMax - sinkMin) * sliderSink.GetSliderValue();//沈めたい深さ
        if(sliderSink.GetSliderValue() >= 0.02f)
        {
            rigid.velocity =new Vector2(rigid.velocityX, rigid.velocityY * 0.98f);
            rigid.position = new Vector2(rigid.position.x, rigid.position.y + (valueDepth - trans.position.y) * 0.025f);
            if (trans.position.y > valueDepth)
            {
                gameObject.GetComponent<PhysicsWater>().Sink(sinkPower);
            }

        }


        //if (Input.GetMouseButtonDown(0))
        //{ 
        //    sinkPowerY = 0.0f;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    tapPositionY = Input.mousePosition.y;

        //    if (tapPositionY - oldTapPositionY > sinkPowerY)
        //    {
        //        sinkPowerY = tapPositionY - oldTapPositionY;
        //    }

        //    //Debug.Log("tapPosition" + tapPositionY);
        //   // Debug.Log("oldTapPosition" + oldTapPositionY);
        //    //Debug.Log("sinkPower" + sinkVelocityY);
        //    oldTapPositionY = Input.mousePosition.y;//1フレーム前のタップポジション
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    if (sinkPowerY * sinkPowerYAdjustment > sinkPowerYMax)
        //    {
        //        sinkPowerYDecision = sinkPowerYMax;
        //    }
        //    else if (sinkPowerY * sinkPowerYAdjustment <= sinkPowerYMax)
        //    {
        //        sinkPowerYDecision = sinkPowerY * sinkPowerYAdjustment;
        //    }
        //    gameObject.GetComponent<PhysicsWater>().Sink(sinkPowerYDecision);
        //    //Debug.Log("sinkPower" + sinkPowerY);
        //}
    }
}
