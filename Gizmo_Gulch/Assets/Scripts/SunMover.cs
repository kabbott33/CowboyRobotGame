using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SunMover : MonoBehaviour
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
    private float step;


    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.NightMorning += NightMorning;
        EventController.instance.MorningNoon += MorningNoon;
        EventController.instance.NoonEvening += NoonEvening;
        EventController.instance.EveningNight += EveningNight;
        EventController.instance.ResetDay += ResetDay;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.F1)) 
        {
            NightMorning();
        }
        if (Input.GetKey(KeyCode.F2))
        {
            MorningNoon();
        }
        if (Input.GetKey(KeyCode.F3))
        {
            NoonEvening();
        }
        if (Input.GetKey(KeyCode.F4))
        {
            EveningNight();
        }
        if (Input.GetKey(KeyCode.F5))
        {
            ResetDay();
        }
    }
    public void NightMorning()
    {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, morningPosition.rotation, step);
    }

    public void MorningNoon()
    {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, noonPosition.rotation, step);
    }
    public void NoonEvening()
    {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, eveningPosition.rotation, step);
    }
    public void EveningNight()
    {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, postDuskPosition.rotation, step);
    }

    public void ResetDay()
    {
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, predawnPosition.rotation, 10*step);
    }

}
