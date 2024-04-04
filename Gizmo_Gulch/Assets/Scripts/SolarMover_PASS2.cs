using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;



public class SolarMover_PASS2 : MonoBehaviour
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

    //Rotation speed
    public float rotationSpeed;

    private Transform targetPosition;
    public float timer = 20f; // Initial timer value
    private bool isMoving = false; // Flag to indicate if the sun is moving

    // Start is called before the first frame update
    void Start()
    {
        // Start the sun position changing loop
        InvokeRepeating("ChangeSunPosition", 0, timer); // Call ChangeSunPosition every 20 seconds starting from the beginning
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Rotate towards the target position
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition.position - sun.position);
            sun.rotation = Quaternion.RotateTowards(sun.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the target position
            sun.position = Vector3.MoveTowards(sun.position, targetPosition.position, speed * Time.deltaTime);

            // Check if the sun has reached the target position
            if (sun.position == targetPosition.position)
            {
                isMoving = false; // Stop moving
            }
        }
    }

    // Method to change the sun's position
    void ChangeSunPosition()
    {
        // Determine the next sun position based on the current position
        targetPosition = GetNextSunPosition();

        // Restart the timer
        CancelInvoke("ChangeSunPosition");
        Invoke("ChangeSunPosition", timer);

        // Start moving
        isMoving = true;
    }

    // Method to get the next sun position
    Transform GetNextSunPosition()
    {
        if (sun.rotation == predawnPosition.rotation)
        {
            return morningPosition;
        }
        else if (sun.rotation == morningPosition.rotation)
        {
            return noonPosition;
        }
        else if (sun.rotation == noonPosition.rotation)
        {
            return eveningPosition;
        }
        else if (sun.rotation == eveningPosition.rotation)
        {
            return postDuskPosition;
        }
        else
        {
            return predawnPosition;
        }
    }
}
