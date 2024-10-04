using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Camera camera;
    private Vector3 Offset;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

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
        Debug.Log("drag");
        transform.position = GetMousePos() + Offset;
    }
    private Vector3 GetMousePos()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
