using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using JetBrains.Annotations;

public class Camera_Array_Switcher : MonoBehaviour
{
    // Start is called before the first frame update

    public List<CinemachineVirtualCamera> cameras;
    public int currentCamera;
    void Start()
    {
        currentCamera = 0;

    }

    public void Switch()
    {
        currentCamera += 1;
        foreach (var i in cameras)
        {   
            i.Priority = 1;
        }
        cameras[currentCamera].Priority = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
