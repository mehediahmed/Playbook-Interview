using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectViewer : MonoBehaviour
{
    #region public variables
    public GameObject objectToView;
    public Vector3 lastMousePosition;
    public float clickDistance = 0f;
    public static ObjectViewer Instance { get { return _instance; } }
    #endregion

    #region private variables
    private static ObjectViewer _instance;
    private ObjectTransformation objectTransformation;
    private GameObject objectToViewInstance;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        objectToViewInstance = Instantiate(objectToView);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickObject();
        }
        else if (Input.GetMouseButton(0))
        {
            releaseObject();
        }
    }
    #endregion

    #region Public Methods
    public void ResetObject() 
    {
        Destroy(objectToViewInstance);
        objectToViewInstance = Instantiate(objectToView);
    }
    #endregion

    #region Private Methods
    private void clickObject()
    {
        objectTransformation = null;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            ObjectTransformation tran = hit.collider.GetComponent<ObjectTransformation>();
            if (tran != null)
            {
                lastMousePosition = Input.mousePosition;
                objectTransformation = tran;
            }

        }
        Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Color.blue);

    }
    private void releaseObject()
    {
        Vector3 distance = Input.mousePosition - lastMousePosition;
        clickDistance = distance.magnitude;

        if (objectTransformation != null)
        {

            if (objectTransformation.VerticalDrag == true)
            {
                if (Input.mousePosition.y > lastMousePosition.y)
                {

                }

                else if (Input.mousePosition.y < lastMousePosition.y)
                {
                    clickDistance = -clickDistance;
                }
            }
            if (objectTransformation.HorizontalDrag == true)
            {
                if (Input.mousePosition.x > lastMousePosition.x)
                {
                    clickDistance = -clickDistance;

                }

                else if (Input.mousePosition.x < lastMousePosition.x)
                {

                }
            }

            objectTransformation.Transform();

        }
    }
    #endregion
}
