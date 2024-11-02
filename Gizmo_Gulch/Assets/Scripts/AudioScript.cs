using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;
    public AudioSource audioSource1;
    public AudioClip morningSong, noonSong, eveningSong, alarmSound;

    public void PlayMorningSong()
    {
        audioSource1.clip = morningSong;
        audioSource1.Play();
    }

    public void PlayNoonSong()
    {
        audioSource1.clip = noonSong;
        audioSource1.Play();
    }

    public void PlayEveningSong()
    {
        audioSource1.clip = eveningSong;
        audioSource1.Play();
    }

    public void PlayAlarmSound()
    {
        audioSource1.clip = alarmSound;
        audioSource1.Play();
    }

    public void StopAlarm()
    {
        audioSource1.Stop();
    }
}
