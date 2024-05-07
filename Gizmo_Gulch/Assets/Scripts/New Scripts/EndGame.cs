using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public AudioClip taDa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EndTheGame()
    {
        StartCoroutine(Hooray());
    }

    IEnumerator Hooray()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
