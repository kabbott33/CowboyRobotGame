using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    public string startBlockName;

    public GameObject player;

    private Quaternion storedRotation;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CONTROLLER");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue()
    {
        if (this.gameObject.GetComponent<NPCMovement>().canTalk == true)
        {
            flowchart.ExecuteBlock(startBlockName);
            LookAtPlayer();
            EventController.instance.UnlockCursor();
            EventController.instance.PauseTime();

        }

    }

    public void LookAtPlayer()
    {
        storedRotation = transform.rotation;
        this.transform.LookAt(player.transform);
    }

    public void LookAway()
    {
        this.transform.eulerAngles = storedRotation.eulerAngles;
        EventController.instance.LockCursor();
        EventController.instance.ResumeTime();
    }
    //public void LookAtPlayer()


}