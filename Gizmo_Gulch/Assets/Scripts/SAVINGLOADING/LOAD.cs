using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class LOAD : MonoBehaviour
{
    public float ticks;
    public string phase;
    public Flowchart flowchart;
    public GameObject player;
    public Transform playerTransform;

    
    // Start is called before the first frame update
    public void Load()
    {
        flowchart.ExecuteBlock("LOAD");
        phase = flowchart.GetStringVariable("phase");
        //playerTransform = flowchart.GetTransformVariable("playerPosition");
        ticks = flowchart.GetFloatVariable("ticks");

        setTicks();
        //setSun();
        setPlayerPosition();
        Node_Manager_V2.instance.LoadNodeStrings();
    }

    public void setTicks()
    {
        CLOCK_V2.instance.setTicks(ticks);
    }
    public void setPlayerPosition()
    {
        player.transform.position = new Vector3((flowchart.GetFloatVariable("pposX")),
                                                                        (flowchart.GetFloatVariable("pposY")), 
                                                                        (flowchart.GetFloatVariable("pposZ")));
        player.transform.eulerAngles = new Vector3((flowchart.GetFloatVariable("protX")),
                                                                              (flowchart.GetFloatVariable("protY")),
                                                                              (flowchart.GetFloatVariable("protZ")));


    }

    public void setSun()
    {
        SUN_V3.instance.sunSetTest((flowchart.GetFloatVariable("sunrotX")),
                                                        (flowchart.GetFloatVariable("sunrotY")),
                                                         (flowchart.GetFloatVariable("sunrotZ")));
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
