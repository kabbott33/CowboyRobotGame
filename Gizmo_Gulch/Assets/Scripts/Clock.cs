using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float tickInterval = 1.0f; // Interval between ticks in seconds
    private float ticks = 0; // Number of ticks
    public GameObject clockHand;
    public TextMeshProUGUI tickTimer;

    public float tickRate = 1f;
    public float nextTick = 0.0f;


    public bool timePassing = true;


    void Start()
    {
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


        if (Time.time > nextTick && timePassing)
        {
            nextTick = Time.time + tickRate;
            ticks++;
        }
    }
    public void DayStart()
    {
        if (ticks == 0 && timePassing)
        {
            EventController.instance.isMorningNoon();
        }
    }
    public void MorningEnd()
    {
        if (ticks == 24 && timePassing) 
        {
            Debug.Log("plumpis");
            EventController.instance.isNoonEvening();
        }
    }
    public void NoonEnd()
    {
        if (ticks == 48&&timePassing)
        {
            EventController.instance.isEveningNight();
        }
    }
    public void EveningEnd()
    {
        if (ticks == 72&&timePassing)
        {
            EventController.instance.isResetDay();
           clockHand.transform.rotation = Quaternion.Euler(0, 0, 180);
            ticks = -24;
        }
    }

    public void PauseTime()
    {
        timePassing = false;
    }

    public void ResumeTime()
    {
        timePassing = true;
    }

    public void IncrementTick()
    {
        if ((ticks != 24)||(ticks!=48)||(ticks!=72))
            {
            ticks ++;
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
}