using Fungus;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Alarm : MonoBehaviour
{
    public Image button;
    public AudioClip alarm;
    public bool canBeep = true;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Image>();
        StartCoroutine(BeepBeep());
        StartCoroutine(Blinking());
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BeepBeep()
    {
        if (canBeep)
        {
            
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            StartCoroutine(BeepBeep());
        }

    }
    IEnumerator Blinking()
    {
        if (canBeep)
        {
            button.tintColor = Color.red;
            yield return new WaitForSeconds(1f);
            button.tintColor = Color.black;
            yield return new WaitForSeconds(1f);
            StartCoroutine(Blinking());
        }

    }

    public void ShutUp()
    {

    }

}
