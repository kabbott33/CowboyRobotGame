using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Fungus;



public class EndOfDay : MonoBehaviour
{
    public static EndOfDay instance;

    public float timerTimeRemaining;

    //for "go to bed" script
    public GameObject camera;

    public GameObject clockUi;

    //timer+text mesh variables
    public TMP_Text timerText;
     public TMP_Text warningText;
    // public TMP_Text warning2Text;
    // public TMP_Text phaseOfDayText;
    //public AudioClip warningSound;

     private bool isTimerRunning = false;

    //to check if player made to the bed in time or not 
     //private bool playerAtTheBed = false;

    //player and tp point to teleport player
    public GameObject Player;
    public GameObject TPref;

    //end of day screen stuff
    public GameObject skillStuff;
    public GameObject blackScreen;
    public GameObject startButton;


    void Start()
    {
        instance = this;
        timerText.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SleepAction();
    }

    public void SleepAction()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && (Clock.instance.ticks == 72) && (Clock.instance.timePassing == false))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, EventController.instance.interactDistance))
            {
                Debug.Log(hit.collider.name);

                //give the bed that player is gonna sleep in, tag "bed"
                if (hit.collider.CompareTag("Bed"))
                {
                    StopTimer();
                    EventController.instance.PauseTime();
                    Clock.instance.ticks = -1;
                    EventController.instance.UnlockCursor();
                    EventController.instance.ResetDay();
                }
            }
        }
    }

    //starts the timer
    public void StartTimer()
    {
        if (Clock.instance.ticks == 72 && (Clock.instance.timePassing == false) && !isTimerRunning)
        {


            // Turn on the timer
            TurnTimerUION();
            isTimerRunning = true;
            //clockUi.gameObject.SetActive(false);
            // Start the timer coroutine
            EventController.instance.StartTimerScript();
        }
    }

    //ends day
    public void StopTimer()
    {
        if (isTimerRunning)
        {
            // Turn off the timer
            TurnTimerUIOFF();
            //turn on the end day stuff
            PlayerToBed();
        }

        isTimerRunning = false;
        // Stop the coroutine if it's running
        EventController.instance.StopTimerScript();
        //playerAtTheBed = true;
    }

    
    //turns on the end of day UI and teleports player to bed
    public void PlayerToBed()
    {
        //toogle end of day ui stuff
        TurnEndOfDayUION();

        //teleport player to the bed position
        Player.transform.rotation = TPref.transform.rotation;
        Player.transform.position = TPref.transform.position;
    }

    public void TurnTimerUION()
    {
            warningText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
     }
       
    public void TurnTimerUIOFF()
     {
            warningText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
        
    }

    public void TurnEndOfDayUIOFF()
    {
            blackScreen.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            skillStuff.gameObject.SetActive(false);
    }

    public void TurnEndOfDayUION()
    {
        blackScreen.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        skillStuff.gameObject.SetActive(true);
    }
}
