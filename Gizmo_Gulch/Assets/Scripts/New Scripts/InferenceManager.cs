using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InferenceManager : MonoBehaviour
{
    public static InferenceManager instance;

    // public List<GameObject> explosivesPrereqs;

    public GameObject explosivesPreReq1;
    public GameObject explosivesPreReq2;
    public GameObject explosivesPreReq3;
    public int explosivePrereqsMet;
    public GameObject explosiveNode;


    //public List<GameObject> nightPrereqs;

    public GameObject nightPreReq1;
    public GameObject nightPreReq2;
    public GameObject nightPreReq3;
    public int nightPrereqsMet;
    public GameObject nightNode;


    //public List<GameObject> meansConvictionPrereqs;

    public GameObject meansPreReq1;
    public GameObject meansPreReq2;
    public GameObject meansPreReq3;
    public int meansConvictionPrereqsMet;
    public GameObject meansNode;


    //public List<GameObject> motiveConvictionPrereqs;
    public GameObject motivePreReq1;
    public GameObject motivePreReq2;
    public GameObject motivePreReq3;
    public int motiveConvictionPrereqsMet;
    public GameObject motiveNode;


    //public List <GameObject> timeConvictionPrereqs;
    public GameObject timePreReq1;
    public GameObject timePreReq2;
    public GameObject timePreReq3;
    public int timeConvictionPrereqsMet;
    public GameObject timeNode;
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
        Explosives();
        Night();
        MeansConviction();
        MotiveConviction();
        TimeConviction();
    }

    /*
    public void Explosives()
    {
        foreach (GameObject obj in explosivesPrereqs)
        {
            if (NodeBoardManager.instance.activeNodes.Contains(obj.name))
            {
                explosivePrereqsMet ++;
            }
        }
        if (explosivePrereqsMet >= 2) 
        {
            explosiveNode.SetActive(true);
        }
    }
    */

    public void Explosives()
    {
        int iasj;
        iasj = (countPrereqs(explosivesPreReq1, explosivesPreReq2, explosivesPreReq3, NodeBoardManager.instance.activeNodes));
        explosivePrereqsMet = iasj;

       if  (iasj >=2)
        {
            explosiveNode.SetActive(true);
        }
    }

    public void Night()
    {
        int iasj;
        iasj = (countPrereqs(nightPreReq1, nightPreReq2, nightPreReq3, NodeBoardManager.instance.activeNodes));
        nightPrereqsMet = iasj;

        if (iasj >= 2)
        {
            nightNode.SetActive(true);
        }
    }

    public void MeansConviction()
    {
        int iasj;
        iasj = (countPrereqs(meansPreReq1, meansPreReq2, meansPreReq3, NodeBoardManager.instance.activeNodes));
        meansConvictionPrereqsMet = iasj;

        if (iasj >= 2)
        {
            meansNode.SetActive(true);
        }
    }

    public void MotiveConviction()
    {
        int iasj;
        iasj = (countPrereqs(motivePreReq1, motivePreReq2, motivePreReq3, NodeBoardManager.instance.activeNodes));
        motiveConvictionPrereqsMet = iasj;

        if (iasj >= 2)
        {
            motiveNode.SetActive(true);
        }
    }

    public void TimeConviction()
    {
        int iasj;
        iasj = (countPrereqs(timePreReq1, timePreReq2, timePreReq3, NodeBoardManager.instance.activeNodes));
        timeConvictionPrereqsMet = iasj;

        if (iasj >= 2)
        {
            timeNode.SetActive(true);
        }
    }

    public int countPrereqs(GameObject go1, GameObject go2, GameObject go3, List<string> namesList)
    {
       string name1 = go1.name;
        string name2 = go2.name;
        string name3 = go3.name;
        int count = 0;

        for (int i = 0; i < namesList.Count(); i++)
        {
            if ((namesList[i] == name1) || (namesList[i] == name2) || (namesList[i] == name3))
            {//check if the item exists in the list
                count++;
            }
        }
        return count;
    }





    /*
    public void Night()
    {
        foreach (GameObject obj in nightPrereqs)
            if (NodeBoardManager.instance.activeNodes.Contains(obj.name))
            {
                nightPrereqsMet ++;
            }
        if (nightPrereqsMet >= 2)
        {
            nightNode.SetActive(true);
        }
    }

    public void MeansConviction()
    {
        foreach (GameObject obj in meansConvictionPrereqs)
        {
            if (NodeBoardManager.instance.activeNodes.Contains(obj.name))
            {
                meansConvictionPrereqsMet ++;
            }
        }
        if (meansConvictionPrereqsMet >= 2)
        {
            meansNode.SetActive(true);
        }
    }
    public void MotiveConviction()
    {
        foreach ( GameObject obj in motiveConvictionPrereqs)
        {
            if (NodeBoardManager.instance.activeNodes.Contains(obj.name))
            {
                motiveConvictionPrereqsMet ++;
            }
        }
        if (motiveConvictionPrereqsMet >= 2)
        {
            motiveNode.SetActive(true);
        }
    }
    public void TimeConviction()
    {
        foreach(GameObject obj in timeConvictionPrereqs)
        {
            if (NodeBoardManager.instance.activeNodes.Contains(obj.name))
            {
                timeConvictionPrereqsMet ++;
            }
        }
        if (timeConvictionPrereqsMet >= 2)
        {
            timeNode.SetActive(true);
        }
    }

    */
}
