using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Node_Manager_V2 : MonoBehaviour
{
    public static Node_Manager_V2 instance; 
    public List<int> activeNodes;
    public List<int> lockedNodes;


    public GameObject newNodeGrid;
    public GameObject nodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        AddNode(1);
    }

    public void AddNode(int nodeID)
    {
        activeNodes.Add(nodeID);
        GenerateNode(nodeID);
        Debug.Log("Added node" + (nodeID));
    }

    public void LockNode(int nodeID)
    {
        lockedNodes.Add(nodeID);
        Inference_Manager_V2.instance.InferenceCheck();
        ExperienceManager.instance.NodeAdded();
    }

    public void GenerateNode(int nodeID)
    {
        GameObject newNode = Instantiate(nodePrefab, newNodeGrid.transform.position, newNodeGrid.transform.rotation);
        newNode.transform.SetParent(newNodeGrid.transform);
        newNode.transform.SetAsLastSibling();
        newNode.GetComponent<Node_V2>().Initialize(nodeID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
