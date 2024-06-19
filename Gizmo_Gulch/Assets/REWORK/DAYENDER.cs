using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DAYENDER : MonoBehaviour
{
    public static DAYENDER instance;

    public float timerTimeRemaining;

    //for "go to bed" script
    public GameObject camera;

    public GameObject clockUi;

    //timer+text mesh variables

    // public TMP_Text warning2Text;
    // public TMP_Text phaseOfDayText;
    //public AudioClip warningSound;



    //to check if player made to the bed in time or not 
    //private bool playerAtTheBed = false;

    //player and tp point to teleport player
    public GameObject Player;
    public GameObject TPref;

    //end of day screen stuff
    public GameObject endDayUI;


    void Start()
    {
        instance = this;
        endDayUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        SleepAction();
    }

    public void SleepAction()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && (CLOCK_V2.instance.ticks == 72) && (CLOCK_V2.instance.timePassing == false))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, EventController.instance.interactDistance))
            {
                Debug.Log(hit.collider.name);

                //give the bed that player is gonna sleep in, tag "bed"
                if (hit.collider.CompareTag("Bed"))
                {
                    EventController.instance.StopTimer();
                    EventController.instance.PauseTime();
                    CLOCK_V2.instance.ticks = -1;
                    EventController.instance.UnlockCursor();
                    EventController.instance.ResetDay();
                    TurnEndOfDayUION();
                    
                }
            }
        }
    }
    public void TeleportPlayer()
    {
        Player.transform.rotation = TPref.transform.rotation;
        Player.transform.position = TPref.transform.position;
    }
    public void TurnEndOfDayUIOFF()
    {
        endDayUI.SetActive (false);
    }

    public void TurnEndOfDayUION()
    {
        endDayUI.SetActive(true);
    }

    public void DayEnded()
    {
        EventController.instance.dayEnding = false;
        endDayUI.SetActive(false);
    }
}
