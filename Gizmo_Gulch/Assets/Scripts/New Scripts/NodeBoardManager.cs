using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBoardManager : MonoBehaviour
{
    public static NodeBoardManager instance;

    public List<string> activeNodes = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        activeNodes.Add("a2_location");
    }

    public void AddNode(string nodeIdentifier) 
    {
        activeNodes.Add(nodeIdentifier);
        InferenceManager.instance.InferenceCheck();
        Debug.Log("Added node" + (nodeIdentifier));
        ExperienceManager.instance.NodeAdded();
    }



    // Update is called once per frame
    void Update()
    {
        
    }


}
