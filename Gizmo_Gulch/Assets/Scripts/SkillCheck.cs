using Fungus;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillCheck : MonoBehaviour
{
    public float mechanics;
    public float rizz;
    public float emergence;
    public float dastardlyDC;

    public Flowchart flowchart;
    public List<SkillCheck> fungusVariables;

    public float percentage;

    public 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MechanicsCheck()
    {
        //if (Random.Range(0, Mechanics)) { }
    }

    public void RizzCheck() 
    {

    }
    public void EmergenceCheck()
    {
       // if (Random.Range(0, CheckDC)) 
        {

        }
    }

    public void Success()
    {
        Debug.Log("success");
        flowchart.SetBooleanVariable("success", true);
    }
    public void Failure() 
    {
        Debug.Log("failiure");
        flowchart.SetBooleanVariable("success", false);
    }

    public void EmergencePreCheck()
    {
        dastardlyDC = flowchart.GetFloatVariable("checkDC");
        Debug.Log(dastardlyDC);
        percentage = ((emergence / dastardlyDC) * 100);

        flowchart.SetStringVariable("checkText", ("Emergence Check:" + rizz + "/" + dastardlyDC + "| (" + percentage + "%)"));
    }

    public void AuthorityPreCheck()
    {
        dastardlyDC = flowchart.GetFloatVariable("checkDC");
        Debug.Log(dastardlyDC);
        percentage = ((rizz / dastardlyDC) * 100);

        flowchart.SetStringVariable("checkText", ("Authority Check:" + rizz + "/" + dastardlyDC + "| (" + percentage + "%)"));
    }

    public void MechanicsPreCheck()
    {
        dastardlyDC = flowchart.GetFloatVariable("checkDC");
        Debug.Log(dastardlyDC);
        percentage = ((mechanics / dastardlyDC) * 100);

        flowchart.SetStringVariable("checkText", ("Mechanics Check:" + rizz + "/" + dastardlyDC + "| (" + percentage + "%)"));
    }

    public void DCTest()
    {

        if (Random.Range(0, 100) < percentage)
        {
            Success();
        }
        else
        {
            Failure();
        }
    }
}
