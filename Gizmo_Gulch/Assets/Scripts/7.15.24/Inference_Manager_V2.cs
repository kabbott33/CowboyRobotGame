using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inference_Manager_V2 : MonoBehaviour
{
    public static Inference_Manager_V2 instance;
    public int[] catDogReqs;
    public int catDogNum;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InferenceCheck()
    {
        //CatDog();
    }

    public void CatDog()
    {
        int catDogCounter = 0;
        foreach(int i in catDogReqs)
        {
            if (Node_Manager_V2.instance.lockedNodes.Contains(i))
            {
                catDogCounter++;
                //Debug.Log("catdogcounter:" + catDogCounter);
            }
        }
        if (catDogCounter >= catDogNum) 
        {
            Node_Manager_V2.instance.AddNode(4);
        }
    }
}
