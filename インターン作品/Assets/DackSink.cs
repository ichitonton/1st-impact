using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DackSink : MonoBehaviour
{
    private bool buttonDownFlag = false;
    public string DackObjName;
    // Update is called once per frame
    void Update()
    {
        if(buttonDownFlag)
        {
            Debug.Log("Hold");
            GameObject.Find(DackObjName).GetComponent<PhysicsWater>().Sink();
        }
        
    }

    public void OnButtonDown()
    {
        buttonDownFlag = true;
    }
    public void OnButtonUp()
    {
        buttonDownFlag = false;
    }
}
