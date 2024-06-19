using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUN_V3 : MonoBehaviour
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
        if (!isRotating)
        {

            StartCoroutine(RotateTowards(morningPosition.rotation));
        }
    }
    public void Noon()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(noonPosition.rotation));
        }
    }
    public void Evening()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(eveningPosition.rotation));
        }
    }
    public void Night()
    {
        if (!isRotating)
        {
             speed = 0.35f;
            //hoorayThisWillSurelyWorkCorrectly = true;
            StartCoroutine(RotateTowards(postDuskPosition.rotation));

        }
    }
    private IEnumerator RotateTowards(Quaternion targetRotation)
    {
        EventController.instance.PauseTime();
        EventController.instance.isRotating = true;
        Quaternion currentRotation = sun.rotation;

        while (Quaternion.Angle(currentRotation, targetRotation) > 0.1f)
        {
            Debug.Log("rotato");
            sun.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, step);
            currentRotation = sun.rotation;
            yield return null;
        }

        EventController.instance.isRotating = false;

        if (!(EventController.instance.dayEnding))
        {
            EventController.instance.ResumeTime();
        }
        else
        {
            speed = 20f;
        }
        
    }

}
