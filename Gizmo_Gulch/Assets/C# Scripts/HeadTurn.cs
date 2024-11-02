using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{
    public float rotationSpeed = 2.0f;  // Speed at which the object will rotate

    private Transform playerTransform;

    void Start()
    {
        // Find the GameObject tagged as "Player" and get its transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("No GameObject found with tag 'Player'.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Determine the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Keep rotation on the Y-axis only

            // Calculate the rotation needed to face the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}