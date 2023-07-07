using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectTransformation : MonoBehaviour
{
    public bool HorizontalDrag = false;
    public bool VerticalDrag = true;
    public GameObject ObjectToTranslate;

    [HideInInspector]
    public Vector3 TranslateVector;
    public virtual void Transform()
    {


    }
}
