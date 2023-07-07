using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : ObjectTransformation
{
    public bool BeginDrag = false;
    public Vector3 Offset;
    private Vector3 mousePosition;
    public override void Transform()
    {
        //ObjectToTranslate.transform.Translate();
    }

    private Vector3 GetMousePos() 
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        ObjectToTranslate.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
