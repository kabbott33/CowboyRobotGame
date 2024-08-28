using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineRenderer_01 : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject lineEnd;
    void Start()
    {
        
    }

    public void InitializeFromNode(Transform preReqTransform, Transform newNodeTransform)
    {
        Vector3 direction = newNodeTransform.position - preReqTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        transform.rotation = rotation;
        // Vector2 lineDirection = this.transform.position - preReqTransform.position;
        //Quaternion lineRotation = Quaternion.LookRotation(lineDirection, Vector2.up);
        this.transform.position = preReqTransform.position;
        //this.transform.rotation = lineRotation;

        StartCoroutine(Elongate(preReqTransform, newNodeTransform));


    }

    public IEnumerator Elongate(Transform preReqTransform, Transform newNodeTransform)
    {
        float distance = Vector2.Distance(lineEnd.transform.position, newNodeTransform.position);
        while (distance > (5))
        {
            
            this.transform.localScale= new Vector3(this.transform.localScale.x, ((this.transform.localScale.y)*1.05f), this.transform.localScale.z);
            distance = Vector2.Distance(lineEnd.transform.position, newNodeTransform.position);
            Debug.Log(distance);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
