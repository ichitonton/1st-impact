using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAndStopBgm : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    private AudioSource audioSource = null;
    public GoalManager goalManager;
    public AudioClip goalSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalManager.GetIsGoal())
        {
            audioSourceBGM.Stop();
            audioSource.PlayOneShot(goalSE);
        }
    }
}
