using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTrigger : MonoBehaviour
{
    [Header("USE THIS TO CALL SOMETHING ON TRIGGER")]
    public UnityEvent triggerEntered;

    [Header("USE THIS TO SET YOUR TRIGGER TYPE, MAKE SURE YOU CHANGE AND ADD YOUR OWN ONES")]
    public TriggerType typeOfTrigger;

    private void Start()
    {
        //EventController.instance.isAfterNoonTime += AfterNoonTime;
        // IF YOU HAVE ANYTHING TO SUBSCRIBE FROM YOUR EVENT CONTROLLER SCRIPT DO IT HERE.
        // FOR EXAMPLE
        // EventController.instance.OnEnd += SubscribedEvent;
    }


    public void SubscribedEvent()
    {
        // TO SHOW AN EXAMPLE OF SUBSCRIBED EVENT. 
    }

    /// <summary>
    /// In OnTriggerEnter you can check for player tags but now you can also check the type of the Trigger
    /// </summary>
    private void KeyPressTrigger()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //TO SHOW YOU AN EXAMPLE OF USING TRIGGER TYPES ENUM

        if (other.tag == "Player")
        {
            
              triggerEntered.Invoke();
            
        }
    }

    public void AfterNoonTime()
    {
        // WHAT MY NPC DOES IN AFTERNOON
    }
}




/// <summary>
/// We have a custom Enum called TriggerType
/// For example i have created 2 different types here
/// You can delete these and create your own custom type for your own game, This is purely for your understanding.
/// Make sure you set this in the Inspector tab in unity Scene view.
/// </summary>
public enum TriggerType
{
    DialogueTrigger,
    DeathTrigger,
    KeyPressTrigger,
    DayNightTrigger
}