using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public GameObject mainCamera;
    public GameObject secondaryCamera;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void SwitchCamera(CameraStates setState)
    {
        switch(setState)
        {
            case CameraStates.Main:
                mainCamera.SetActive(true);
                break;

            case CameraStates.speed:
                mainCamera.SetActive(false);
                break;
        }
    }
}


public enum CameraStates
{

    // anything outside of mono behavior class can be accessed through the entire project (static)
    Main,
    speed
}

// notes: 

// public int Addition(int A, int B)
// {
// int Sum = A+B;
// return Sum;
// }
// Addition(5,10) (declared)
// debug.Logerror(????)
// Addition = function name