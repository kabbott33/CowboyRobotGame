using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSphere : MonoBehaviour
{
    public float rotationSpeed;
    public bool RotateOpositeSide;
    // Start is called before the first frame update
    void Start()
    {
       // Vector3 movement = new Vector3(0f, 0f,distance *Time.fixedDeltaTime);
    }

    private void Orbit()
    {
        if (RotateOpositeSide)
        {
            float rotation = rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up, -rotation);
        }
        else
        {
            float rotation = rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up, rotation);
        }
                  
    }

    // Update is called once per frame
    void Update()
    {
        Orbit();
    }
}
