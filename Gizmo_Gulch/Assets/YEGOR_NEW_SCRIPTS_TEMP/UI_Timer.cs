using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
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
        EventController.instance.timerStart += StartTimerScript;
        EventController.instance.timerStop += StopTimerScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopTimerScript()
    {
        StopCoroutine(Timer());
    } 

    public void StartTimerScript()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        float timeRemaining = totalTimeInSeconds;
        EndOfDay.instance.timerTimeRemaining = timeRemaining;

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
              EndOfDay.instance.StopTimer();
            EventController.instance.PauseTime();
            Clock.instance.ticks = -1;
            EventController.instance.UnlockCursor();
            EventController.instance.ResetDay();
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
}
