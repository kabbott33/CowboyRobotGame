using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRaycast : MonoBehaviour
{
    // private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        //  inventory = GameObject.FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCheck();
    }

   public void PlayerCheck()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && !(EventController.instance.isRotating))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, EventController.instance.interactDistance))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("NPC"))
                    {
                        hit.transform.GetComponent<NPCDialogue>().StartDialogue();
                        Debug.Log("working");
                    }
                {

                }
            }
        }
    }
}