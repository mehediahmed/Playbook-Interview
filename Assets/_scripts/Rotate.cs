using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ObjectTransformation
{
  
    public Vector3 AxisOfRotation = Vector3.right;

    public override void Transform() 
    {
        ObjectToTranslate.transform.Rotate(AxisOfRotation, ObjectViewer.Instance.clickDistance * 0.0025f);
    }
}
