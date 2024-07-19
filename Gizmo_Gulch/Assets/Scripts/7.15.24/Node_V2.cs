using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node_V2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public bool isInBoard;
    public Transform location;
    private NodeSO nodeData;
    public Flowchart flowchart;
    public bool isLockedIn;

    public GameObject newNodeGrid;
    public GameObject scaleNode;

    public GameObject scaler;

    public GameObject outline;

    public AudioSource bruh;

    // Start is called before the first frame update
    void Start()
    {
        outline.SetActive(false);
        newNodeGrid = FindInactiveGameObjectByName("New_Stuff");
        scaler = FindInactiveGameObjectByName("NodeBoardContent");
        flowchart = GameObject.Find("Flowchart01").GetComponent<Flowchart>();
        
    }

    public void Initialize(int nodeID)
    {
        scaleNode = FindInactiveGameObjectByName("ScaleNode");
        this.name = ("Node "+(nodeID.ToString()));
          string path = "Nodes/" + nodeID;
         nodeData = Resources.Load<NodeSO>(path);
        // nodeData = Resources.Load<NodeSO>("Nodes/2");

        if (GameObject.Find(nodeData.location) == null)
        {
            location = FindInactiveGameObjectByName(nodeData.location).transform;
        }
        else
        {
            location = GameObject.Find(nodeData.location).transform;
        }
        
        Debug.Log(nodeData.location);
        this.GetComponent<Image>().raycastTarget = true;

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
                if (Node_Manager_V2.instance.loadingNodes)
                {
                    CheckPreReqs();
                }
            }
        if (nodeData is Default)
            {
                GoToPosition();
            }
        if (nodeData is Inference)
            {
                GoToPosition();
            }

        }
    }

    public void CheckPreReqs()
    {
        if (nodeData is Evidence evidenceNode)
        {
            if (Node_Manager_V2.instance.lockedNodes.Contains(nodeData.prereq))
            {
                int existantAltPreReqs = 0;
                foreach (int i in evidenceNode.altEvidence)
                {
                    if (Node_Manager_V2.instance.lockedNodes.Contains(i))
                    {
                        existantAltPreReqs++;

                    }
                }
                if (existantAltPreReqs == 0)
                {
                    GoToPosition();
                }
                if (existantAltPreReqs == 1)
                {
                    GoToSecondaryPosition();
                }
                if (existantAltPreReqs == 2)
                {
                    GoToTertiaryPosition();
                }
            }
            else;
        }
    }
    public void GoToPosition()
    {
        NormalizeScale();
        this.transform.position = location.position;
        //this.transform.position = GameObject.Find((nodeData.location)).transform.position;
        this.transform.parent = location;
        //this.transform.parent = GameObject.Find((nodeData.location)).transform;
        Node_Manager_V2.instance.LockNode(nodeData.identifier);
        this.GetComponent<Image>().raycastTarget = true;
        isLockedIn = true;
        StartCoroutine(ScaleUpAndDestroy(0.1f));
    }

    public void GoToSecondaryPosition()
    {
        if (nodeData is Evidence evidenceNode)
        {
            NormalizeScale();
            this.transform.position = GameObject.Find(evidenceNode.altLocation1).transform.position;
            this.transform.parent = GameObject.Find(evidenceNode.altLocation1).transform;
            Node_Manager_V2.instance.LockNode(nodeData.identifier);
            this.GetComponent<Image>().raycastTarget = true;
            isLockedIn = true;
            StartCoroutine(ScaleUpAndDestroy(0.1f));
        }
    }
    public void GoToTertiaryPosition()
    {
        if (nodeData is Evidence evidenceNode)
        {
            NormalizeScale();
            this.transform.position = GameObject.Find(evidenceNode.altLocation2).transform.position;
            this.transform.parent = GameObject.Find(evidenceNode.altLocation1).transform;
            Node_Manager_V2.instance.LockNode(nodeData.identifier);
            this.GetComponent<Image>().raycastTarget = true;
            isLockedIn = true;
            StartCoroutine(ScaleUpAndDestroy(0.1f));
        }
    }

    public void NormalizeScale()
    {
        scaler = FindInactiveGameObjectByName("NodeBoardContent");
        this.transform.localScale = scaler.transform.localScale;
        /*
        this.GetComponent<Image>().raycastTarget = true;
        this.transform.SetParent(newNodeGrid.transform);
        this.transform.SetAsLastSibling();
        */
        /*
        
        this.transform.localScale = scaleNode.transform.localScale;
        this.transform.localScale = scaleNode.transform.localScale;
        this.transform.localScale = scaleNode.transform.localScale;
        */
        //this.transform.SetAsLastSibling();
        //Debug.Log(nodeData.prereq.ToString());
        //this.transform.localScale = GameObject.Find(nodeData.prereq.ToString()).transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //mouse events
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("nodeclicked");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            flowchart.SetStringVariable("evidenceDescription", nodeData.description);
            flowchart.ExecuteBlock("EVIDENCE");
        }

        if ((eventData.button == PointerEventData.InputButton.Left) && (Node_Manager_V2.instance.lockedNodes.Contains(nodeData.identifier)))
        {
            if (nodeData is Photo photoNode)
            {
                Debug.Log("photoclicked");
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
            if (DropChecker())
            {
                {
                    this.GetComponent<Image>().raycastTarget = true;
                    //transform.SetParent(board.transform);
                    transform.SetAsLastSibling();
                }
            }
           else
            {
                this.GetComponent<Image>().raycastTarget = true;
                this.transform.SetParent(newNodeGrid.transform);
                this.transform.SetAsLastSibling();
            }
    }


    GameObject FindInactiveGameObjectByName(string name)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }

    //drop checker
    public bool DropChecker()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        bool hit = false;
        foreach (RaycastResult result in results)
        {
            if ((result.gameObject.name)== "NodeBoard")
            {
                hit = true;
            }
        }
        
        if (hit == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator ScaleUpAndDestroy(float duration)
    {
        if (this.gameObject.activeInHierarchy)
        {
            bruh.Play();
            Debug.Log("isthisshietevenworking");
            outline.SetActive(true);
            Vector3 originalScale = outline.transform.localScale;
            Vector3 targetScale = originalScale * 1.25f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                outline.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            outline.transform.localScale = targetScale;
            Destroy(outline);
        }
    }
    

    //inference coroutine
}
