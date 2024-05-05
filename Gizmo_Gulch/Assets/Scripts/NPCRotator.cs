using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RotateTowardsPoint : MonoBehaviour
{
    public List<Transform> targetPoints = new List<Transform>(); // List of points your NPC should rotate towards
    public float rotationSpeed = 5f; // Speed of rotation

    private int currentTargetIndex = 0; // Index of the current target point
    private bool isRotationAllowed = true; // Flag to control rotation

    // Update is called once per frame
    void Update()
    {
        // Check if there are any target points set and rotation is allowed
        if (targetPoints.Count > 0 && isRotationAllowed)
        {
            // Get the direction to the current target point
            Vector3 direction = targetPoints[currentTargetIndex].position - transform.position;

            // Ensure that the direction is not zero to avoid division by zero
            if (direction != Vector3.zero)
            {
                // Create a rotation that looks in the direction of the current target point
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Smoothly rotate towards the target rotation
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Check if the NPC is close enough to the current target point
            if (Vector3.Distance(transform.position, targetPoints[currentTargetIndex].position) < 0.1f)
            {
                // Move to the next target point if rotation is allowed
                if (isRotationAllowed)
                {
                    currentTargetIndex = (currentTargetIndex + 1) % targetPoints.Count;
                    isRotationAllowed = false; // Disable rotation until another script enables it
                    // You can call a function from another script here to indicate that rotation is allowed again
                }
            }
        }
    }

    // Function to enable rotation when called by another script
    public void EnableRotation()
    {
        isRotationAllowed = true;
    }
}