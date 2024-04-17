using Fungus;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillCheck : MonoBehaviour
{
    public int Mechanics;
    public int Rizz;
    public int Emergence;
    public int CheckDC;

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

    }
    public void Failure() 
    {
       
    }

    public void DCTest()
    {
        CheckDC =  flowchart.GetIntegerVariable("checkDC");
        Debug.Log(CheckDC);
    }
}
