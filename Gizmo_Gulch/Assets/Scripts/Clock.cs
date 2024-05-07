using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float tickInterval = 1f; // Interval between ticks in seconds
    private float ticks = 0; // Number of ticks
    public GameObject clockHand;
    public GameObject blackScreen;
    public GameObject startButton;
    public GameObject clockUi;
    public TextMeshProUGUI tickTimer;

    public float tickRate = 1f;
    public float nextTick = 0.0f;


    public bool timePassing = true;

    public Flowchart flowchart;

    public GameObject camera;

    //timer+text mesh variables
    public TMP_Text timerText;
    public TMP_Text warningText;
    public TMP_Text warning2Text;
    public TMP_Text phaseOfDayText;
    public AudioClip warningSound;

    public int totalTimeInSeconds = 30;
    private bool isTimerRunning = false;
    private bool warningActive = false;
    private bool playerDidMakeIt = false;

    public GameObject Player;
    public GameObject TPref;

    public GameObject skillStuff;
    void Start()
    {
        EventController.instance.pauseTime += PauseTime;
        EventController.instance.resumeTime += ResumeTime;
        // Start the timer
        // InvokeRepeating("IncrementTick", 3, tickInterval);
        timerText.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);


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
        StartTimer();
        SleepAction();

        if (Input.GetKeyDown(KeyCode.U))
        {
            IncrementTick();
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



    public void SleepAction()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && (ticks == 72) && (!timePassing))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, EventController.instance.interactDistance))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Bed"))
                {


                    // EventController.instance.ResumeTime();
                    //Debug.Log("PISSPOO");
                    HiShree();
                    EventController.instance.PauseTime();
                    ticks = -1;
                    EventController.instance.UnlockCursor();
                    EventController.instance.ResetDay();
                    //DoTweenFadeIN_OUT.instance.FadeIn(5);
                    skillStuff.SetActive(true) ;
                    StopTimer();


                }



            }
        }
    }

    public void StartTimer()
    {
        if (ticks == 72 && !timePassing && !isTimerRunning)
        {
            StartCoroutine(Timer());
            // Turn on the timer
            warningText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            // Start the timer coroutine
            isTimerRunning = true;
            clockUi.gameObject.SetActive(false);
        }
    }


    public void StopTimer()
    {
        if (isTimerRunning)
            // Turn off the timer
            timerText.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        skillStuff.SetActive(true);
        isTimerRunning = false;
        // Stop the coroutine if it's running
        StopAllCoroutines();
        playerDidMakeIt = true;
    }

    public void TogleBlackScreen()
    {
        startButton.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
    }

    public void HiShree()
    {
        startButton.gameObject.SetActive(true);
        blackScreen.gameObject.SetActive(true);
            TeleportPlayer();
    }

    public void TeleportPlayer()
    { 
        Player.transform.rotation = TPref.transform.rotation;
        Player.transform.position = TPref.transform.position;
    }

    private IEnumerator Timer()
    {
        float timeRemaining = totalTimeInSeconds;

        while (timeRemaining > 0)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            int milliseconds = Mathf.FloorToInt((timeRemaining - Mathf.Floor(timeRemaining)) * 1000);

            timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);

            // Check if it's time to activate the warning
            if (timeRemaining <= 30 && !warningActive)
            {
                warningActive = true;
                StartCoroutine(ActivateWarning());
            }

            yield return new WaitForSeconds(0.01f); // Update every 0.01 seconds
            timeRemaining -= 0.01f;
        }

        timerText.text = "00:00.000";
        if (timeRemaining < 0.1)
        {
            HiShree();
            StopTimer();
            EventController.instance.UnlockCursor();
            EventController.instance.ResetDay();
            EventController.instance.PauseTime();
            ticks = -1;
        }
        // Optionally, you can do something when the timer reaches 0
    }

    private IEnumerator ActivateWarning()
    {
        while (true)
        {
            warningText.gameObject.SetActive(true);

            // Play warning sound if provided
            if (warningSound != null)
            {
                AudioSource.PlayClipAtPoint(warningSound, transform.position);
            }

            yield return new WaitForSeconds(1f); // Toggle every half a second

            warningText.gameObject.SetActive(false);

            yield return new WaitForSeconds(1f); // Toggle every half a second
        }
    }


    public void PhaseDayText()
    {
        phaseOfDayText.text = flowchart.GetStringVariable("phase");
        //phaseOfDayText.text = "phase";
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

    public void TurnTheClockUION()
    {
        clockUi.gameObject.SetActive(true);
    }

    public void IncrementTick()
    {
        if (ticks==24||ticks==48||ticks==72)
        {

        }

        else
        {
            ticks++;
            tickTimer.text = "TICK" + ticks;
        }
    }
    /*
    // Function to increment ticks
    void IncrementTick()
    {
 
    }

    */

    //tick += time.unscaleddeltatime*multiplier

    public void SkillsOff()
    {
        skillStuff.SetActive(false);
    }
}
