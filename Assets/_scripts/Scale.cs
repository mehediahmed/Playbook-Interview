using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : ObjectTransformation
{

    public override void Transform()
    {
        ObjectToTranslate.transform.parent.localScale = new Vector3(ObjectToTranslate.transform.parent.localScale.x + ObjectViewer.Instance.clickDistance * 0.00025f, 
            ObjectToTranslate.transform.parent.localScale.y + ObjectViewer.Instance.clickDistance * 0.00025f, 
            ObjectToTranslate.transform.parent.localScale.z + ObjectViewer.Instance.clickDistance * 0.00025f);
    }
}
