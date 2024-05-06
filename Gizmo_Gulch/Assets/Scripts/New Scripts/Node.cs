using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;
using TMPro;

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
    public GameObject altLocation;

   // public GameObject linePrefab;

    public GameObject line;

    public bool isInference;
    public bool isEvidence;

    public GameObject altEvidence1;
    public GameObject altEvidence2;

    

    public bool defaultNode;

    public TextMeshProUGUI text;
    

    public bool isLockedIn;
    void Start()
    {
        identifier = this.gameObject.name;
        evidence =this.GetComponent<Image>();

        if (defaultNode || isInference)
        {
            goToPosition();
        }


        text.raycastTarget = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!(isInBoard)&&!(isLockedIn))
        {
            if (isEvidence) 
            {
                Debug.Log("Start Drag");
                parentAfterDrag = transform.parent;
                transform.SetParent(transform.root);
                transform.SetAsLastSibling();
                evidence.raycastTarget = false;
            }

        }


    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (!isInBoard)

        if (!(isLockedIn)) 
        {
            if (evidence)
            {
                Debug.Log("Dragin");
                transform.position = Input.mousePosition;
            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!(isLockedIn))
        {
            Debug.Log("End Drag");
            transform.SetParent(parentAfterDrag);
            evidence.raycastTarget = true;
        }



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
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            goToPosition();
        }
        */
        /*
        if ((NodeBoardManager.instance.activeNodes.Contains(preReq))&&isInBoard)
        {
            goToPosition();
        }
        */
    }

    public void InTheBoard()
    {
        isInBoard = true;
    }

    public void goToPosition()
    {
        if (isEvidence)
        {
            if (NodeBoardManager.instance.activeNodes.Contains(preReq.name) && isInBoard)
           // if (NodeBoardManager.instance.activeNodes.Contains(preReq.name) )
            {
                Debug.Log("Evidence Placed");



                      if ((NodeBoardManager.instance.activeNodes.Contains(altEvidence1.name)) || (NodeBoardManager.instance.activeNodes.Contains(altEvidence2.name)))
                       {
                            this.transform.position = altLocation.transform.position;
                            
                    isLockedIn = true;

                    if (!NodeBoardManager.instance.activeNodes.Contains(identifier))
                            {
                        NodeBoardManager.instance.AddNode(identifier);

                    }
                    //line.SetActive(true);
                       }


                else
                {
                    this.transform.position = location.transform.position;
                    NodeBoardManager.instance.AddNode(identifier);
                    isLockedIn = true;
                    if (!NodeBoardManager.instance.activeNodes.Contains(identifier))
                        
                    {
                        NodeBoardManager.instance.AddNode(identifier);

                    }

                    //line.SetActive(true);
                }


                //DrawLine();
            }
        }
        else if (isInference || defaultNode) 
        {
            if (!(NodeBoardManager.instance.activeNodes.Contains (identifier))) 
            {
                this.transform.position = location.transform.position;
                NodeBoardManager.instance.AddNode(identifier);
                isInBoard = true;
                isLockedIn = true;
            }

            //if ((NodeBoardManager.instance.activeNodes.Contains(preReq.name))|| (NodeBoardManager.instance.activeNodes.Contains(preReq2.name)))

        }




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

    /*
    public void DrawLine()    
    {
        GameObject line = Instantiate(linePrefab, this.transform.position, this.transform.rotation);    
        line.transform.SetParent(this.transform);

        line.GetComponent<UILine>().GetEndpoint(preReq.transform);

          
    }
    */
}
