using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private int numKeys = 0;    //What does this variable represent? This variable reperesents the number of keys the player has. 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;     //What is this variable used for?   A: This variable is used to send out an invisible ray and return information on whatever it hits.

            if(Physics.Raycast(this.transform.position, transform.forward, out hit, 5f))     //Please describe how this raycast is working by describing the variables being passed to it.   A: The raycast sends a ray from the origin "this.transform.position" in the direction of the Vector 3 "transform.forward". If it hits anything before reaching it's maximum distance (5f), it returns a value of true and stores the information of whatever was hit (as the local variable "hit").
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Door door = hit.collider.GetComponent<Door>();

                    if(numKeys > 0 && door.CanOpenDoor())   //Why can't we just look for the door's "canPlayerOpenDoor" variable directly instead of using the function?   A:  Because the canPlayerOpenDoor variable is private in the Door script, while the bool we're accessing here is public,
                    {
                        door.OpenDoor();    //What are ALL the conditions that have to be met in order for this door to be opened? Hint: There are 5.   A:  The E key must be pressed, the raycast out from the player's camera must hit something, the thing that it hits must be a door, the player must have one or more keys and the door must not have already been opened (CanOpenDoor must be true).
                        numKeys--;          //What is the purpose of this line?   A:  This line subtracts 1 from the numKeys variable, so that keys are consumed on use.
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)     //When is OnTriggerEnter called?   A: This function is called when the collider of this game object (the first person controller) enters the collider of any another game object.
    {
        if(other.CompareTag("Key"))
        {
            numKeys++;                      //What is the purpose of this line?   A: This line adds 1 to the numKeys variable, so that the player can now open one more door.
            Destroy(other.gameObject);      //What object is being destroyed and why do we have to destroy it?   A: The object being destroyed is the Key, which we need to destroy so that the player cannot get an infinite amount of keys by stepping into and out of it over and over again.
        }
    }
}
