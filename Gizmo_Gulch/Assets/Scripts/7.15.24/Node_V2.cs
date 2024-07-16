using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node_V2 : MonoBehaviour
{
    public bool isInBoard;
    public Transform location;
    private NodeSO nodeData;
    public Flowchart flowchart;
    public bool isLockedIn;

   
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart01").GetComponent<Flowchart>();
    }

    public void Initialize(int nodeID)
    {
          string path = "Nodes/" + nodeID;
         nodeData = Resources.Load<NodeSO>(path);
        // nodeData = Resources.Load<NodeSO>("Nodes/2");

        location = GameObject.Find((nodeData.location)).transform;
        

        if (nodeData != null)
        {
            if (nodeData is Evidence evidenceNode)
            {

                if (nodeData is Photo photoNode)
                {
                    this.GetComponent<Image>().sprite = photoNode.photo;
                }
                if (nodeData is Testimony testimonyNode)
                {

                }
            }
        if (nodeData is Default)
            {
                GoToPosition();
            }
        if (nodeData is Inference)
            {

            }

        }
    }

    public void CheckPreReqs()
    {
        if (nodeData is Evidence evidenceNode)
        {
            int existantPreReqs = 0;
            foreach (int i in evidenceNode.altEvidence)
            {
                if (Node_Manager_V2.instance.lockedNodes.Contains(i))
                {
                    existantPreReqs++;

                }
            }
            if (existantPreReqs == 0)
            {
                GoToPosition();
            }
            if (existantPreReqs == 1)
            {
                GoToSecondaryPosition();
            }
            if (existantPreReqs ==2)
            {
                GoToTertiaryPosition();
            }
        }
    }
    public void GoToPosition()
    {
        this.transform.position = location.position; 
        this.transform.parent = location;
        Node_Manager_V2.instance.LockNode(nodeData.identifier);
    }

    public void GoToSecondaryPosition()
    {
        if (nodeData is Evidence evidenceNode)
        {
            this.transform.position = GameObject.Find(evidenceNode.altLocation1).transform.position;
            this.transform.parent = GameObject.Find(evidenceNode.altLocation1).transform;
            Node_Manager_V2.instance.LockNode(nodeData.identifier);
        }
    }
    public void GoToTertiaryPosition()
    {
        if (nodeData is Evidence evidenceNode)
        {
            this.transform.position = GameObject.Find(evidenceNode.altLocation2).transform.position;
            this.transform.parent = GameObject.Find(evidenceNode.altLocation1).transform;
            Node_Manager_V2.instance.LockNode(nodeData.identifier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //mouse events
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            flowchart.SetStringVariable("evidenceDescription", nodeData.description);
            flowchart.ExecuteBlock("EVIDENCE");
        }

        if ((eventData.button == PointerEventData.InputButton.Left) && (Node_Manager_V2.instance.lockedNodes.Contains(nodeData.identifier)))
        {
            if (nodeData is Photo photoNode)
            {
                Debug.Log("photclicked");
            }
            if (nodeData is Testimony testimonyNode)
            {
                Debug.Log("testimonyclicked");
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left) && (!(Node_Manager_V2.instance.lockedNodes.Contains(nodeData.identifier))))
        {
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            this.GetComponent<Image>().raycastTarget = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left) && (!(Node_Manager_V2.instance.lockedNodes.Contains(nodeData.identifier))))
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left) && (!(Node_Manager_V2.instance.lockedNodes.Contains(nodeData.identifier))))
        {
            this.GetComponent<Image>().raycastTarget = true;
            //transform.SetParent(board.transform);
            transform.SetAsLastSibling();
        }
    }


    //inference coroutine
}
