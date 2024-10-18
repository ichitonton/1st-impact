using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSink : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Input.GetMouseButton(0))
        {
            slider.value = 0;
        }
    }

    public float GetSliderValue()
    {
        return slider.value;
    }
}
