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
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Image>();
        StartCoroutine(BeepBeep());
        StartCoroutine(Blinking());

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BeepBeep()
    {
        if (canBeep)
        {
            AudioSource audio = GetComponent<AudioSource>();
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
