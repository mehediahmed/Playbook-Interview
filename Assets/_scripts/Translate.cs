using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : ObjectTransformation
{
    public Vector3 Offset;
    private Vector3 mousePosition;
    public override void Transform()
    {
        ObjectToTranslate.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

}
