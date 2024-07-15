using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node_V2 : MonoBehaviour
{
    private NodeSO nodeData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(int nodeID)
    {
          string path = "Nodes/" + nodeID;
         nodeData = Resources.Load<NodeSO>(path);
       // nodeData = Resources.Load<NodeSO>("Nodes/2");
        if (nodeData != null)
        {
            Debug.Log("String: " + nodeData.description);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
