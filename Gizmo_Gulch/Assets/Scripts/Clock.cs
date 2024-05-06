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
    public TextMeshProUGUI tickTimer;

    public float tickRate = 1f;
    public float nextTick = 0.0f;


    public bool timePassing = true;

    public Flowchart flowchart;

    public GameObject camera;


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
        SleepAction();
        




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
        }
    }
    public void MorningEnd()
    {
        if (ticks == 24 && timePassing) 
        {
            Debug.Log("plumpis");
            EventController.instance.Noon();
            EventController.instance.NPCsToNoon();
            flowchart.SetStringVariable(("phase"), "noon");
        }
    }
    public void NoonEnd()
    {
        if (ticks == 48&&timePassing)
        {
            EventController.instance.Evening();
            EventController.instance.NPCsToEvening();
            flowchart.SetStringVariable(("phase"), "evening");
        }
    }
    
    public void EveningEnd()
    {
        if (ticks == 72&&timePassing)
        {
           
            EventController.instance.Night();
            //EventController.instance.ResetDay();
            EventController.instance.NPCsToNight();
           clockHand.transform.rotation = Quaternion.Euler(0, 0, 180);
            //ticks = -24;
            //EventController.instance.PauseTime();
        }
    }
    /*
    public void SleepTime()
    {
        if (ticks == 73 && timePassing)
        {
            Debug.Log("POOPISS");
            EventController.instance.PauseTime();
           
        }
    }
*/
    public void SleepAction()
    {
        if ((Input.GetKeyDown(KeyCode.F)) && (ticks == 72 ) && (!timePassing))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, EventController.instance.interactDistance))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Bed"))
                {


                    // EventController.instance.ResumeTime();
                    //Debug.Log("PISSPOO");
                    EventController.instance.PauseTime();
                    ticks = -10;
                       EventController.instance.UnlockCursor();
                        EventController.instance.ResetDay();
                    
                       

                }
                

               
            }
        }
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
