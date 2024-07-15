using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Node_Manager_V2 : MonoBehaviour
{

    public List<int> activeNodes;
    public GameObject nodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddNode(int nodeID)
    {
        activeNodes.Add(nodeID);
        GenerateNode(nodeID);
        Inference_Manager_V2.instance.InferenceCheck();
        Debug.Log("Added node" + (nodeID));
        ExperienceManager.instance.NodeAdded();
    }

    public void GenerateNode(int nodeID)
    {
        GameObject newNode = Instantiate(nodePrefab, this.transform.position, this.transform.rotation);
        newNode.GetComponent<Node_V2>().Initialize(nodeID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
