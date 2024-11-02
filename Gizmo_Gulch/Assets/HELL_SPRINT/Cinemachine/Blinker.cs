using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public Image blackscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Wake()
    {
        StartCoroutine(WakeFade());
    }

    public void Blink()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WakeFade()
    {
        var tempcolor = blackscreen.color;
        float currentOpacity = tempcolor.a;
        tempcolor.a = 1f;
        while (tempcolor.a != 0f)
        {
            Mathf.Lerp(currentOpacity, 1, 0.5f);
        }
        return null;
    }
}
