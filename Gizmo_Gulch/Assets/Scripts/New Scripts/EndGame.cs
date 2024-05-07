using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EndTheGame()
    {
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
