using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularPhysics : MonoBehaviour
{
    public float moveAngularBegin = 100.0f;
    public float addVelocityAngular = 3.0f;
    Transform trans;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        rigid.angularVelocity = -moveAngularBegin;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
