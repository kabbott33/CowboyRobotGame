using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    public string startBlockName;
    // Start is called before the first frame update
    void Start()
    {

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