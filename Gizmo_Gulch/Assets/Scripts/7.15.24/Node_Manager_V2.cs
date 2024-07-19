using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System;

public class Node_Manager_V2 : MonoBehaviour
{
    public static Node_Manager_V2 instance; 
    public List<int> activeNodes;
    public List<int> lockedNodes;

    public Flowchart flowchart;

    public GameObject newNodeGrid;
    public GameObject nodePrefab;

    public string savedAddedNodes;
    public string savedLockedNodes;

    public bool loadingNodes;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //AddNode(000);
        savedAddedNodes = ("1");
        savedLockedNodes = ("1");
    }

    public void AddNode(int nodeID)
    {
        activeNodes.Add(nodeID);
        GenerateNode(nodeID);
        Debug.Log("Added node" + (nodeID));
        UpdateAddedNodeString(nodeID);
    }

    public void LockNode(int nodeID)
    {
        lockedNodes.Add(nodeID);
        Inference_Manager_V3.instance.InferenceCheck();
        //ExperienceManager.instance.NodeAdded();
        UpdateLockedNodeString(nodeID);
    }

    public void GenerateNode(int nodeID)
    {
        GameObject newNode = Instantiate(nodePrefab, this.transform.position, this.transform.rotation);
        newNode.transform.SetParent(newNodeGrid.transform);
        newNode.transform.SetAsLastSibling();
        newNode.GetComponent<Node_V2>().Initialize(nodeID);
    }

    public void UpdateAddedNodeString(int id)
    {
        savedAddedNodes += " "+(id);
    }

    public void UpdateLockedNodeString(int id)
    {
        savedLockedNodes += " " + (id);
    }

    public void SaveNodeStrings()
    {
        flowchart.SetStringVariable("addedNodes", savedAddedNodes);
        flowchart.SetStringVariable("lockedNodes", savedLockedNodes);
    }
    public void LoadNodeStrings()
    {
        loadingNodes = true;
        savedAddedNodes = flowchart.GetStringVariable("addedNodes");
        savedLockedNodes = flowchart.GetStringVariable("lockedNodes");

        int[] nodesToAdd = (Array.ConvertAll(savedAddedNodes.Split(' '), int.Parse));
        foreach (int i in nodesToAdd)
        {
            AddNode(i);
        }
        int[] nodesToLock =(Array.ConvertAll(savedLockedNodes.Split(' '), int.Parse));
        foreach (int i in nodesToLock)
        {
            LockNode(i);
        }
        loadingNodes = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
