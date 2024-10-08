using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject player;
    private bool isGoal;
    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ÉvÉåÉCÉÑÅ[Ç∆êGÇÍÇΩÇÁ
        if (player.GetComponent<Collision2D>() == collision)
        {
            Debug.Log("isGoal true");
            isGoal = true;
        }
    }

    public bool GetIsGoal()
    {
        return isGoal;
    }
}
