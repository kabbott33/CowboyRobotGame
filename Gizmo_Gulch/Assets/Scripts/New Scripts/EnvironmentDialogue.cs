using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    public string startBlockName;

    //public GameObject player;

    //private Quaternion storedRotation;


    // Start is called before the first frame update
    void Start()
    {
     //   player = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue()
    {

            flowchart.ExecuteBlock(startBlockName);



    }



}
