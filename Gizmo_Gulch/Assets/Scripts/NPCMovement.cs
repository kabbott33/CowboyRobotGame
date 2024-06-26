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
    public GameObject NPC;
    private NavMeshAgent agent;

    private Transform currentPosition;

    public GameObject nightPosition;
    public GameObject morningPosition;
    public GameObject noonPosition;
    public GameObject eveningPosition;

    public bool canTalk = true;

    void Start()
    {
        NPC = this.gameObject;
        //EventController.instance.moveNPC += MoveToNextTarget;

        EventController.instance.npcsToMorning += NPCsToMorning;
        EventController.instance.npcsToNoon += NPCsToNoon;
        EventController.instance.npcsToEvening += NPCsToEvening;
        EventController.instance.npcsToNight += NPCsToNight;


        agent = NPC.GetComponent<NavMeshAgent>();
       // MoveToNextTarget(); // Start moving towards the first target
    }

    public void NPCsToMorning()
    {
        agent.SetDestination(morningPosition.transform.position);
        currentPosition = morningPosition.transform;
        canTalk = false;
    }

    public void NPCsToNoon()
    {
        agent.SetDestination(noonPosition.transform.position);
        currentPosition = noonPosition.transform;
        canTalk = false;
    }

    public void NPCsToEvening()
    {
        agent.SetDestination(eveningPosition.transform.position);
        currentPosition = eveningPosition.transform;
        canTalk = false;
    }

    public void NPCsToNight()
    {
        agent.SetDestination(nightPosition.transform.position);
        currentPosition = nightPosition.transform;
        canTalk = false;
    }

    void Update()
    {
  
        if ((!agent.pathPending && agent.remainingDistance < 0.1f)&&!canTalk)
        {
            NPC.transform.rotation = currentPosition.rotation;
            canTalk=true;
            
        }



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
