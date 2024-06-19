using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TIMERTIME : MonoBehaviour
{

    public TMP_Text timerText;
    public TMP_Text warningText;
    public TMP_Text phaseOfDayText;
    public AudioClip warningSound;

    public int totalTimeInSeconds = 30;
    private bool isTimerRunning = false;
    private bool warningActive = false;



    // Start is called before the first frame update
    void Start()
    {
        warningText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        EventController.instance.timerStart += StartTimer;
        EventController.instance.timerStop += StopTimer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopTimer()
    {
        StopCoroutine(Timer());
        TurnTimerUIOFF();
        isTimerRunning = false;
        Debug.Log("testeroo");
    }

    public void StartTimer()
    {
        TurnTimerUION();
        StartCoroutine(Timer());
        isTimerRunning = true;
    }

    private IEnumerator Timer()
    {
        float timeRemaining = totalTimeInSeconds;
        DAYENDER.instance.timerTimeRemaining = timeRemaining;

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
        //when timer is <0.1 do the stuff in bracketsws
        timerText.text = "00:00.000";
        if (timeRemaining < 0.1)
        {
            EventController.instance.StopTimer();
            EventController.instance.PauseTime();
            CLOCK_V2.instance.ticks = -1;
            EventController.instance.UnlockCursor();
            EventController.instance.ResetDay();
            DAYENDER.instance.TurnEndOfDayUION();
        }

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

    /*
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
    */
    /*
    //ends day
    public void StopTimer()
    {
        if (isTimerRunning)
        {
            // Turn off the timer
            TurnTimerUIOFF();
            //turn on the end day stuff
            // PlayerToBed();
        }

        isTimerRunning = false;
        // Stop the coroutine if it's running
    
        //playerAtTheBed = true;
    }

    */
}
