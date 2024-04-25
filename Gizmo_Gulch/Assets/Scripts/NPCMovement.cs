using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public Transform[] targets; // Array to hold multiple targets
    private int currentTargetIndex = 1; // Index of the current target
    private NavMeshAgent agent;

    void Start()
    {
        EventController.instance.moveNPC += MoveToNextTarget;
        agent = GetComponent<NavMeshAgent>();
        MoveToNextTarget(); // Start moving towards the first target
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

    public void MoveToNextTarget()
    {
        // Increment the target index or reset to 0 if reached the end
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        agent.SetDestination(targets[currentTargetIndex].position); // Set the destination to the new target
    }
}
