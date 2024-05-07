using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMover_V2 : MonoBehaviour
{
    // Sun transform
    public Transform sun;

    //Sun positions
    public Transform predawnPosition;
    public Transform morningPosition;
    public Transform noonPosition;
    public Transform eveningPosition;
    public Transform postDuskPosition;

    public bool hoorayThisWillSurelyWorkCorrectly;

    //Sun movement speed
    public float speed;
    private float step;

    public bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.morning += Morning;
        EventController.instance.noon += Noon;
        EventController.instance.evening += Evening;
        EventController.instance.night += Night;
        EventController.instance.resetDay += ResetDay;
        // Event subscriptions remain unchanged

        this.transform.rotation = predawnPosition.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

    }

    // Method to start rotating towards predawn position
    public void ResetDay()
    {
       // this.transform.rotation = predawnPosition.rotation;

    
        if (!isRotating)
        {
            
            speed = 9000;
            //hoorayThisWillSurelyWorkCorrectly = true;
            StartCoroutine(RotateTowards(predawnPosition.rotation));
         
        }
    
    }

    // Method to start rotating towards morning position
    public void Morning()
    {
        /*
        this.transform.rotation = predawnPosition.rotation;
        speed = 20f;
        */
        
        if (!isRotating)
        {
     
            StartCoroutine(RotateTowards(morningPosition.rotation));
        }
        
    }

    // Method to start rotating towards noon position
    public void Noon()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(noonPosition.rotation));
        }
    }

    // Method to start rotating towards evening position
    public void Evening()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(eveningPosition.rotation));
        }
    }

    // Method to start rotating towards post-dusk position
    public void Night()
    {
        if (!isRotating)
        {
            speed = 0.35f;
            hoorayThisWillSurelyWorkCorrectly=true;
            StartCoroutine(RotateTowards(postDuskPosition.rotation));
          
        }
    }

    // Coroutine to rotate towards a given target rotation
    private IEnumerator RotateTowards(Quaternion targetRotation)
    {
        EventController.instance.PauseTime();
        //EventController.instance.MoveToNextTarget();


        EventController.instance.isRotating = true;
        Quaternion currentRotation = transform.rotation;

        // Start rotating towards the target rotation
        while (Quaternion.Angle(currentRotation, targetRotation) > 0.1f)
        {

                transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, step);
                currentRotation = transform.rotation;
                // Wait for the next frame
                yield return null;
      

        }

        // Rotation completed
        EventController.instance.isRotating = false;

        if (!hoorayThisWillSurelyWorkCorrectly)
        {
            EventController.instance.ResumeTime();
        }
        else if (hoorayThisWillSurelyWorkCorrectly) 
        {
            speed = 20;
            
        }
        
    }

    public void WorkinLikeADog()
    {
        hoorayThisWillSurelyWorkCorrectly = false;
    }
}