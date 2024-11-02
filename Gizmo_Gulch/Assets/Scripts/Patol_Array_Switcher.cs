using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patol_Array_Switcher : MonoBehaviour
{
    public List<GameObject> patrolPoints;
    public int currentPatrolPoint;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentPatrolPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SPP()
    {
        Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHFUCK");
        currentPatrolPoint++;
        agent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
    }

}
