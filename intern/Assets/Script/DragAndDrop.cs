using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Camera camera;
    private Vector3 Offset;
    private Rigidbody2D rigid;
    //Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
    private void OnMouseDown()
    {
        Offset = gameObject.transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        //Debug.Log("drag");
        rigid.position = GetMousePos() + Offset;
        rigid.gravityScale = 0.0f;
    }
    private void OnMouseUp()
    {
        rigid.gravityScale = 2.0f;
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private Vector3 GetMousePos()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
