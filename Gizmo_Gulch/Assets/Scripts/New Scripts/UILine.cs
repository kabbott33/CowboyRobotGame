using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UILine : MonoBehaviour
{
    public bool canExpand;
    public RectTransform rectTransform;
    public Transform lineEnd;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canExpand = true;

        // this.transform.rotate(endPoint);
        //Quaternion _lookRotation =  Quaternion.LookRotation((endPoint.transform.position - transform.position).normalized);
        //transform.rotation = _lookRotation;
        //this.transform.rotation.look

        //this.transform.LookAt(endPoint);
    }

    private void FixedUpdate()
    {

        if (Vector2.Distance((new Vector2(lineEnd.position.x, lineEnd.position.y)), (new Vector2(endPoint.position.x, endPoint.position.y))) > 1f)
        {
            Debug.Log("testtttttttttt");
            //this.transform.localScale = 3f;
            this.transform.localScale = this.transform.localScale*1.1f;

        }
    }

    public void GetEndpoint(Transform transform)
    {
        endPoint = transform;
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
