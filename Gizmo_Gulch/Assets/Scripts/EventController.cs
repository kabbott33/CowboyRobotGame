using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventController : MonoBehaviour
{
    //Making this a singleton Class
    public static EventController instance;

    //public bools
    public float interactDistance = 5f;

    public bool isPaused;
    public bool isRotating;

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

    public event Action morning;
    public event Action noon;
    public event Action evening;
    public event Action night;
    public event Action resetDay;

    public event Action pauseTime;
    public event Action resumeTime;

    // public event Action moveNPC;

    public event Action npcsToMorning;
    public event Action npcsToNoon;
    public event Action npcsToEvening;
    public event Action npcsToNight;

    // lock/unlock cursor stuff

    public event Action lockCursor;
    public event Action unlockCursor;

    

    public void Morning()
    {
        if(morning != null) 
        {
            morning();
        }
    }
    public void Noon()
    {
        if (noon != null)
        {
           noon();
        }
    }
    public void Evening()
    {
        if (evening != null)
        {
            evening();
        }
    }
    public void Night()
    {
        if (night != null)
        {
            night();
        }
    }
    public void ResetDay()
    {
        if (resetDay != null)
        {
            resetDay();
        }
    }

    public void PauseTime()
    {
        if (pauseTime != null)
        {
            pauseTime();
        }
    }

    public void ResumeTime()
    {
        if (resumeTime != null)
        {
            resumeTime();
        }
    }

    public void NPCsToMorning()
    {
        if (npcsToMorning != null)
        {
            npcsToMorning();
        }
    }

    public void NPCsToNoon()
    {
        if (npcsToNoon != null)
        {
            npcsToNoon();
        }
    }

    public void NPCsToEvening()
    {
        if (npcsToEvening != null)
        {
            npcsToEvening();
        }
    }

    public void NPCsToNight()
    {
        if (npcsToNight != null)
        {
            npcsToNight();
        }
    }


    /*
    public void MoveToNextTarget()
    {
        if (moveNPC != null)
        {
            moveNPC();
        }
    }
    */
    public void LockCursor()
    {
        if (lockCursor != null)
        {
            lockCursor();
        }
    }

    public void UnlockCursor()
    {
        if (unlockCursor != null)
        {
            unlockCursor();
        }
    }

   
}

