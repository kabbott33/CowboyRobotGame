using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class Node : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    public string identifier;   
    public GameObject preReq;
    public bool noPreReq;

    //public Image image;
    public Flowchart flowchart;
    public string description;
    public bool isInBoard = false;

    public Image evidence;
    public Transform parentAfterDrag;

    public GameObject location;

    public GameObject linePrefab;

    
    void Start()
    {
        identifier = this.gameObject.name;
        evidence =this.GetComponent<Image>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!(isInBoard))
        {
            Debug.Log("Start Drag");
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            evidence.raycastTarget = false;
        }


    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragin");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        evidence.raycastTarget = true;


       // goToPosition();
        //DropIntoBoard();
    }
    // Start is called before the first frame update

    /*
    public void DropIntoBoard()
    {

    }
    */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            goToPosition();
        }

        /*
        if ((NodeBoardManager.instance.activeNodes.Contains(preReq))&&isInBoard)
        {
            goToPosition();
        }
        */
    }

    public void goToPosition()
    {
        if (NodeBoardManager.instance.activeNodes.Contains(preReq.name) && isInBoard)
        {
            Debug.Log("googoogaga");
            this.transform.position = location.transform.position;
            NodeBoardManager.instance.AddNode(identifier);
            DrawLine();
        }

        /*
        if ((Vector2.Distance(this.transform.position, location.transform.position)) > 0.01f)
        {

        }
        */
    }

    public void OnPointerClick(PointerEventData eventData)
    {


        flowchart.SetStringVariable("evidenceDescription",description);
        flowchart.ExecuteBlock("EVIDENCE");
    }



    /*
    public void OnPoint(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        evidence.raycastTarget = true;

        //DropIntoBoard();
    }
    */

    public void DrawLine()    
    {
        GameObject line = Instantiate(linePrefab, this.transform.position, this.transform.rotation);    
        line.transform.SetParent(this.transform);

        line.GetComponent<UILine>().GetEndpoint(preReq.transform);

          
    }
}
