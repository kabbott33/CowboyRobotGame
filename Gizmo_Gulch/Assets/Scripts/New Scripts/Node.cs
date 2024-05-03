using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    public string identifier; 
    public string preReq;

    //public Image image;
    public Flowchart flowchart;
    public string description;
    public bool isInBoard;
    // Start is called before the first frame update
    void Start()
    {
        if (NodeBoardManager.instance.activeNodes.Contains(preReq))
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {

        }
    }



}
