using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private bool canPlayerOpenDoor = true;      //Look at this line for a hint to a question in the KeyManager script!

    [SerializeField] private float doorOpenTime = 2f;

    public bool CanOpenDoor()
    {
        return canPlayerOpenDoor;
    }

    public void OpenDoor()
    {
        canPlayerOpenDoor = false;                                                  //Why do we have to set this variable to false? A: So that the door cannot be opened multiple times, and the player does not waste keys by pressing E on a door that is already open.
        this.transform.DOMoveY(this.transform.position.y + 4f, doorOpenTime);       //What is this line doing?   A: This line is moving the door 4 unity up from it's current position over a period of 2 seconds.
    }
}
