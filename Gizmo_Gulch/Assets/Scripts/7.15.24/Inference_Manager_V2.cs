using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inference_Manager_V2 : MonoBehaviour
{
    public static Inference_Manager_V2 instance;
    public List<int> catDogReqs;
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

    public void DepreciatedInferenceCheck()
    {
        CatDog();
    }

    public void CatDog()
    {
        
        if (CountCommonElements(catDogReqs, Node_Manager_V2.instance.lockedNodes) >= catDogNum) 
        {
            Node_Manager_V2.instance.AddNode(4);
        }
    }

    public static int CountCommonElements(List<int> list1, List<int> list2)
    {
        HashSet<int> set = new HashSet<int>(list2);
        int count = 0;

        foreach (int num in list1)
        {
            if (set.Contains(num))
            {
                count++;
            }
        }

        return count;
    }
}
