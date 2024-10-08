using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    private Transform cameraTrans;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPosition =  new Vector3(player.GetComponent<Transform>().position.x + offset.x, offset.y, -10.0f);
        cameraTrans.position = cameraPosition;


    }
}
