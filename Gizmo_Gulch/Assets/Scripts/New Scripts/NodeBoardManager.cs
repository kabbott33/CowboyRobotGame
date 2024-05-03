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
    }

    public void AddNode(string nodeIdentifier) 
    {
        activeNodes.Add(nodeIdentifier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
