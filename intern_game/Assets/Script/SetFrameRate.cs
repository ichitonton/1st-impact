using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    public int frameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 60fps�ɐݒ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}