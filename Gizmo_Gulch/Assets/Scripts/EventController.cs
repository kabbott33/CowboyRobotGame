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

    public event Action timerStart;
    public event Action timerStop;
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

    public bool dayEnding = false;

    

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

    public void StartTimer()
    {
        if (timerStart != null)
        {
            timerStart();
        }
    }

    public void StopTimer()
    {
        if (timerStop != null)
        {
            timerStop();
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

