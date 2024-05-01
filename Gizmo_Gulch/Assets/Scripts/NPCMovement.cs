using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    /*
    public Transform[] targets; // Array to hold multiple targets
    private int currentTargetIndex = 1; // Index of the current target
     */
    private NavMeshAgent agent;
   

    public GameObject nightPosition;
    public GameObject morningPosition;
    public GameObject noonPosition;
    public GameObject eveningPosition;

    void Start()
    {
        //EventController.instance.moveNPC += MoveToNextTarget;

        EventController.instance.npcsToMorning += NPCsToMorning;
        EventController.instance.npcsToNoon += NPCsToNoon;
        EventController.instance.npcsToEvening += NPCsToEvening;
        EventController.instance.npcsToNight += NPCsToNight;


        agent = GetComponent<NavMeshAgent>();
       // MoveToNextTarget(); // Start moving towards the first target
    }

    public void NPCsToMorning()
    {
        agent.SetDestination(morningPosition.transform.position);
    }

    public void NPCsToNoon()
    {
        agent.SetDestination(noonPosition.transform.position);
    }

    public void NPCsToEvening()
    {
        agent.SetDestination(eveningPosition.transform.position);
    }

    public void NPCsToNight()
    {
        agent.SetDestination(nightPosition.transform.position);
    }

    void Update()
    {
        /*
        // Check if NPC has reached the current target
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            MoveToNextTarget(); // Move to the next target
        }
        //I need to make it so the npcs only move when the sun changes.
        */


    }

    /*
    public void MoveToNextTarget()
    {
        // Increment the target index or reset to 0 if reached the end
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        agent.SetDestination(targets[currentTargetIndex].position); // Set the destination to the new target
    }
    */
}
