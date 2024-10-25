using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGuideFinger : MonoBehaviour
{
    public RectTransform sinkSlider;
    float sin;
    Color color;
    float alpha = 0;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha);
        Debug.Log(color);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sin = Mathf.Sin(Time.time);

        //“®‚«
        this.transform.position = new Vector3(
            sinkSlider.position.x - sinkSlider.sizeDelta.x * 0.35f, 
            sinkSlider.position.y + sin * sinkSlider.sizeDelta.y * 2.0f, 
            sinkSlider.position.z);

        //“§–¾“x
        if (Input.GetMouseButton(0))
        {
            alpha = 0;
            timer = 0.0f;
        }
        if (!Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer >= 3.0f)
            {
                if (alpha <= 255)
                {
                    alpha += 1.0f;
                }
            }
        }
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha);

    }
}
