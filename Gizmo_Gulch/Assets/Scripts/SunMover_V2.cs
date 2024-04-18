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

    //Sun movement speed
    public float speed;
    private float step;

    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.NightMorning += StartPredawnRotation;
        EventController.instance.MorningNoon += StartMorningRotation;
        EventController.instance.NoonEvening += StartNoonRotation;
        EventController.instance.EveningNight += StartEveningRotation;
        EventController.instance.ResetDay += StartPredawnRotation;
        // Event subscriptions remain unchanged
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

    }

    // Method to start rotating towards predawn position
    public void StartPredawnRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(predawnPosition.rotation));
        }
    }

    // Method to start rotating towards morning position
    public void StartMorningRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(morningPosition.rotation));
        }
    }

    // Method to start rotating towards noon position
    public void StartNoonRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(noonPosition.rotation));
        }
    }

    // Method to start rotating towards evening position
    public void StartEveningRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(eveningPosition.rotation));
        }
    }

    // Method to start rotating towards post-dusk position
    public void StartPostDuskRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateTowards(postDuskPosition.rotation));
        }
    }

    // Coroutine to rotate towards a given target rotation
    private IEnumerator RotateTowards(Quaternion targetRotation)
    {
        isRotating = true;
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
        isRotating = false;
    }
}