using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeedBegin = 1.0f;
    public float moveAngularBegin = 100.0f;
    public float addForcePower = 3.0f;
    public float addVelocityAngular = 3.0f;
    Transform trans;
    Rigidbody2D rigid;
    public Fade fade;

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
    }
}
