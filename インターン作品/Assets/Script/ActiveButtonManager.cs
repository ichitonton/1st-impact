using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtonManager : MonoBehaviour
{
    public string thisButtonBeforStageName;
    public string thisButtoStageName;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Stage0", 3);
        if (PlayerPrefs.GetInt(thisButtonBeforStageName) >= 1)
        {
            gameObject.SetActive(true);
        }

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        if (PlayerPrefs.GetInt(thisButtoStageName) >= 2)
        {
            star1.SetActive(true);
            if (PlayerPrefs.GetInt(thisButtoStageName) >= 3)
            {
                star2.SetActive(true);
                if (PlayerPrefs.GetInt(thisButtoStageName) >= 4)
                {
                    star3.SetActive(true);
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
