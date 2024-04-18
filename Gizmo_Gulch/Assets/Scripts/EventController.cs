using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventController : MonoBehaviour
{
    //Making this a singleton Class
    public static EventController instance;

    private void Awake()
    {
        instance = this;
    }


    /// <summary>
    /// Example of setting up an UnityAction
    /// Here we are creating a simple placeholder event called OnEnd
    /// To subscribe to this event from any of your script Use the syntax
    /// 
    /// * EventController.instance.OnEnd +=  * WHAT EVER YOUR FUNCTION NAME IS ON YOUR SCRIPT *
    /// 
    /// You can create multiple such events, Just make sure you call the correct function where you need it.
    /// In this example, You still have to call "EventController.instance.GameEnded()" somewhere for it to trigger.
    /// </summary>
    /// 

    public event Action OnEnd;
    public void GameEnded()
    {
        if(OnEnd != null)
        {
            OnEnd();
        }
    }

    public event Action NightMorning;
    public event Action MorningNoon;
    public event Action NoonEvening;
    public event Action EveningNight;
    public event Action ResetDay;
    public void isNightMorning()
    {
        if(NightMorning != null) 
        {
            NightMorning();
        }
    }
    public void isMorningNoon()
    {
        if (MorningNoon != null)
        {
            MorningNoon();
        }
    }
    public void isNoonEvening()
    {
        if (NoonEvening != null)
        {
            NoonEvening();
        }
    }
    public void isEveningNight()
    {
        if (EveningNight != null)
        {
            EveningNight();
        }
    }
    public void isResetDay()
    {
        if (ResetDay != null)
        {
            ResetDay();
        }
    }
}
