using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GAMGAMRUN : MonoBehaviour
{

    private NavMeshAgent agent;

    public Transform morningPosition;

    public bool inPosition = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void RUNGAMGAMRUN()
    {
        agent.SetDestination(morningPosition.position);
        this.gameObject.GetComponent<NPCMovement>().isGamGam = false;
    }
    // Update is called once per frame
    void Update()
    {
        if ((!agent.pathPending && agent.remainingDistance < 0.1f) && !inPosition)
        {
            this.transform.rotation = morningPosition.rotation;
            inPosition = true;
            //this.enabled = false;

        }
    }
}
