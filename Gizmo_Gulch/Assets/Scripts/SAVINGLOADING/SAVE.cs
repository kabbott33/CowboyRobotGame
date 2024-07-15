using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAVE : MonoBehaviour
{
    public GameObject player;
    public GameObject saveTransform;
    public Flowchart flowchart;
    public Transform sun;

    public void Save()
    {
       
        saveTransform.transform.position = player.transform.position;
        //saveTransform.transform.eulerAngles = player.transform.eulerAngles;
        

        Vector3 rotation = player.transform.eulerAngles;

        flowchart.SetFloatVariable("pposX", saveTransform.transform.position.x);
        flowchart.SetFloatVariable("pposY", saveTransform.transform.position.y);
        flowchart.SetFloatVariable("pposZ", saveTransform.transform.position.z);
        flowchart.SetFloatVariable("protX", rotation.x);
        flowchart.SetFloatVariable("protY", rotation.y);
        flowchart.SetFloatVariable("protZ", rotation.z);

        Vector3 rotation2 = sun.eulerAngles;

        flowchart.SetFloatVariable("sunrotX", rotation2.x);
        flowchart.SetFloatVariable("sunrotY", rotation2.y);
        flowchart.SetFloatVariable("sunrotZ", rotation2.z);

        if (EventController.instance.isRotating)
        {
            flowchart.SetBooleanVariable("midrotation", true);
        }
        else
        {
            flowchart.SetBooleanVariable("midrotation", false);
        }

        flowchart.ExecuteBlock("SAVE");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
