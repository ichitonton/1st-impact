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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ƐG�ꂽ��
        if (collision.gameObject.name == player.name)
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