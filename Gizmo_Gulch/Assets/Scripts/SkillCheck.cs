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
    }
    public void Failure() 
    {
        Debug.Log("failiure");
    }

    public void DCTest()
    {
        dastardlyDC =  flowchart.GetFloatVariable("checkDC");
        Debug.Log(dastardlyDC);

        float percentage = ((rizz / dastardlyDC) * 100);

        Debug.Log(percentage);
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
