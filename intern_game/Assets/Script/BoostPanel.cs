using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPanel : MonoBehaviour
{
    public GameObject dack;
    private Rigidbody2D dackRigid;
    public float boostPower = 10.0f;
    private Transform trans;
    Vector2 power;
    // Start is called before the first frame update
    void Start()
    {
        dackRigid = dack.GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == dack)
        {
            //Debug.Log("boost!!");
            power.x = -Mathf.Sin(trans.eulerAngles.z *Mathf.Deg2Rad) * boostPower;
            power.y = Mathf.Cos(trans.eulerAngles.z * Mathf.Deg2Rad) * boostPower;

           // Debug.Log(trans.eulerAngles.z);
           // Debug.Log(power);
           // Debug.Log(Mathf.Sin(trans.eulerAngles.z * Mathf.Deg2Rad));
            dackRigid.AddForce(power, ForceMode2D.Force);
        }
    }
}
