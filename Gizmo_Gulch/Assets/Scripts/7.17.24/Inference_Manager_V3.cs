using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inference_Manager_V3 : MonoBehaviour
{
    public static Inference_Manager_V3 instance;

    public List<int> possibleInferences;
    public List<Inference> loadedInferences;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        foreach (int i in possibleInferences)
        {
            string path = "Nodes/" + i;
            loadedInferences.Add(Resources.Load<Inference>(path));
        }
    }

    public void InferenceCheck()
    {
        if (!(Node_Manager_V2.instance.loadingNodes))
        {
            foreach (Inference inference in loadedInferences)
            {
                int metCount = 0;
                foreach (int altReq in inference.additionalPrereqs)
                {
                    if (Node_Manager_V2.instance.lockedNodes.Contains(altReq))
                    {
                        metCount++;
                    }
                }
                if (metCount >= inference.requesitePrereqNum)
                {
                    if ((!(Node_Manager_V2.instance.lockedNodes.Contains(inference.identifier))) && (Node_Manager_V2.instance.lockedNodes.Contains(inference.prereq)))
                    {
                        Inference_UI.instance.StartLoading(inference.identifier);
                        //Node_Manager_V2.instance.AddNode(inference.identifier);
                    }
                }
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
