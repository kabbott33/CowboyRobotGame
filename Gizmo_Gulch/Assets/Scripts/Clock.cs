using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public static Clock instance;

    public float tickInterval = 1f; // Interval between ticks in seconds
    public float ticks = 0; // Number of ticks
    public GameObject clockHand;
    public GameObject clockUi;
    public TextMeshProUGUI tickTimer;
    public TMP_Text phaseOfDayText;

    public float tickRate = 1f;
    public float nextTick = 0.0f;


    public bool timePassing = true;

    public Flowchart flowchart;

    void Start()
    {
        instance = this;
        EventController.instance.pauseTime += PauseTime;
        EventController.instance.resumeTime += ResumeTime;
        // Start the timer
        // InvokeRepeating("IncrementTick", 3, tickInterval);



    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the UI element around the z-axis based on ticks
        float rotationDegrees = ticks * 2.5f;
        clockHand.transform.rotation = Quaternion.Euler(0, 0, 90 - rotationDegrees);
        tickTimer.text = "TICK" + ticks;
        DayStart();
        MorningEnd();
        NoonEnd();
        EveningEnd();
        EndOfDay.instance.StartTimer();
        EndOfDay.instance.SleepAction();


        //DEBUG speed up ticks
        if (Input.GetKeyDown(KeyCode.U))
        {
            IncrementTick();
        }


   
        if (timePassing)
        {
            Debug.Log("time is unpaused");
        }
        else
        {
            Debug.Log("time is paused");
        }


        if (Time.time > nextTick && timePassing)
        {
            nextTick = Time.time + tickRate;
            ticks++;
        }

        //this shit breaks the game because the sun mover co-routine yields any new return during a transition when a transition cannot progress

        /*
        if (EventController.instance.isPaused)
        {
            Time.timeScale = 0;
        }
        else if (!(EventController.instance.isPaused))
        {
            Time.timeScale = 1;
        }
        */
    }
    //MAKE clock only have clock stuff
    //clock end day stauff should be in day restart script that does all the restarting ;lol
    public void DayStart()
    {
        if (ticks == 0 && timePassing)
        {
            Debug.Log("start");
            EventController.instance.Morning();
            EventController.instance.NPCsToMorning();
            flowchart.SetStringVariable(("phase"), "morning");
            PhaseDayText();

        }
    }
    public void MorningEnd()
    {
        if (ticks == 24 && timePassing)
        {

            EventController.instance.Noon();
            EventController.instance.NPCsToNoon();
            flowchart.SetStringVariable(("phase"), "noon");
            PhaseDayText();

        }
    }
    public void NoonEnd()
    {
        if (ticks == 48 && timePassing)
        {
            EventController.instance.Evening();
            EventController.instance.NPCsToEvening();
            flowchart.SetStringVariable(("phase"), "evening");
            PhaseDayText();

        }
    }

    public void EveningEnd()
    {
        if (ticks == 72 && timePassing)
        {

            EventController.instance.Night();
            //EventController.instance.ResetDay();
            EventController.instance.NPCsToNight();
            clockHand.transform.rotation = Quaternion.Euler(0, 0, 180);
            phaseOfDayText.text = " ";

            //ticks = -24;
            //EventController.instance.PauseTime();
        }
    }


    //*
    //public void SleepAction()
    //{
    //    if ((Input.GetKeyDown(KeyCode.F)) && (ticks == 72) && (!timePassing))
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, EventController.instance.interactDistance))
    //        {
    //            //Debug.Log(hit.collider.name);

    //            if (hit.collider.CompareTag("Bed"))
    //            {


    //                HiShree();
    //                EventController.instance.PauseTime();
    //                ticks = -1;
    //                EventController.instance.UnlockCursor();
    //                EventController.instance.ResetDay();

    //                skillStuff.SetActive(true) ;
    //                StopTimer();


    //            }



    //        }
    //    }
    //}

    //public void StartTimer()
    //{
    //    if (ticks == 72 && !timePassing && !isTimerRunning)
    //    {


    //        // Turn on the timer
    //        warningText.gameObject.SetActive(true);
    //        timerText.gameObject.SetActive(true);
    //        isTimerRunning = true;
    //        clockUi.gameObject.SetActive(false);
    //        // Start the timer coroutine
    //        EventController.instance.StartTimer1();
    //        //you need a way to stop the timer when it gets to 000 and then turn it off
    //    }
    //}


    //public void StopTimer()
    //{
    //    if (isTimerRunning)
    //        // Turn off the timer
    //    timerText.gameObject.SetActive(false);
    //    warningText.gameObject.SetActive(false);
    //    blackScreen.gameObject.SetActive(true);
    //    startButton.gameObject.SetActive(true);
    //    skillStuff.SetActive(true);
    //    isTimerRunning = false;
    //    // Stop the coroutine if it's running
    //    StopAllCoroutines();
    //    playerDidMakeIt = true;
    //}

    //public void TogleBlackScreen()
    //{
    //    startButton.gameObject.SetActive(false);
    //    blackScreen.gameObject.SetActive(false);
    //}

    //public void HiShree()
    //{
    //    startButton.gameObject.SetActive(true);
    //    blackScreen.gameObject.SetActive(true);
    //        TeleportPlayer();
    //}

    //public void TeleportPlayer()
    //{ 
    //    Player.transform.rotation = TPref.transform.rotation;
    //    Player.transform.position = TPref.transform.position;
    //}


    //sends the name of the phase to the phase of day textmeshpro
    public void PhaseDayText()
    {
        phaseOfDayText.text = flowchart.GetStringVariable("phase");
    }


    public void PauseTime()
    {
        timePassing = false;
    }

    public void ResumeTime()
    {
        if (!(EventController.instance.isPaused))
        {
            timePassing = true;
        }

    }

    public void IncrementTick()
    {
        if (ticks == 24 || ticks == 48 || ticks == 72)
        {

        }

        else
        {
            ticks++;
            tickTimer.text = "TICK" + ticks;
        }
    }
}
