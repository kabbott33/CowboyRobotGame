using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLINKERS : MonoBehaviour
{
    public AudioSource audioSource; // Assign the AudioSource in the inspector
    public AudioClip soundEffect; // Assign the sound effect AudioClip in the inspector

    // Call this method to play the sound effect
    public void PlayClink()
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning("AudioSource or soundEffect not assigned.");
        }
    }
}
