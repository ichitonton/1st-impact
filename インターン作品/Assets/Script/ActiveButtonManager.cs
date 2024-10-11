using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtonManager : MonoBehaviour
{
    public string thisButtonBeforStageName;
    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.SetInt("Stage0", 3);
       if(PlayerPrefs.GetInt(thisButtonBeforStageName) <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
