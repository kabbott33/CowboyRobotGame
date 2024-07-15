using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CLOCK_V2 : MonoBehaviour
{
    public static CLOCK_V2 instance;

    public float tickInterval = 1f; // Interval between ticks in seconds
    public float ticks = 0; // Number of ticks
    public GameObject clockHand;
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
    }
    void Update()
    {
        float rotationDegrees = ticks * 2.5f;
        clockHand.transform.rotation = Quaternion.Euler(0, 0, 90 - rotationDegrees);
        tickTimer.text = "TICK" + ticks;
        DayStart();
        MorningEnd();
        NoonEnd();
        EveningEnd();

        if (Input.GetKeyDown(KeyCode.U))
        {
            IncrementTick();
        }

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
            EventController.instance.dayEnding = true;
            EventController.instance.StartTimer();
            EventController.instance.Night();
            EventController.instance.NPCsToNight();
            clockHand.transform.rotation = Quaternion.Euler(0, 0, 180);
            flowchart.SetStringVariable(("phase"), "night");
            phaseOfDayText.text = "night";

        }
    }

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
       timePassing = true;
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
            flowchart.SetFloatVariable("ticks", ticks);
            
        }
    }

    public void setTicks(float tickywicky)
    {
        ticks = tickywicky;
        tickTimer.text = "TICK" + ticks;
        flowchart.SetFloatVariable("ticks", ticks);
    }
}
