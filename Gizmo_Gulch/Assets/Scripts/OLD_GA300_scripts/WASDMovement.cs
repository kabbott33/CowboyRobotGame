using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f, playerRotationSpeed = 100.0f, reversedObjectSpeed = 5.0f, rotatingObjectSpeed = 50.0f, rotatingObjectDistance = 5.0f;
    public GameObject reversedObject, rotatingObject;
    public bool clockwiseRotation = true;
    private Vector3 offset;

    void Start()
    {
        if (rotatingObject)
        {
            offset = (rotatingObject.transform.position - transform.position).normalized * rotatingObjectDistance;
            rotatingObject.transform.position = transform.position + offset;
        }
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float rotation = Input.GetKey(KeyCode.A) ? -1 : 1;
            transform.Rotate(0, rotation * playerRotationSpeed * Time.deltaTime, 0);
            if (reversedObject) reversedObject.transform.Rotate(0, rotation * playerRotationSpeed * Time.deltaTime, 0);
        }

        if (reversedObject) reversedObject.transform.Translate(0, 0, -moveVertical * reversedObjectSpeed * Time.deltaTime);

        if (rotatingObject)
        {
            rotatingObject.transform.RotateAround(transform.position, Vector3.up, (clockwiseRotation ? 1 : -1) * rotatingObjectSpeed * Time.deltaTime);
            offset = (rotatingObject.transform.position - transform.position).normalized * rotatingObjectDistance;
            rotatingObject.transform.position = transform.position + offset;
        }
    }

    public void ToggleRotationDirection() => clockwiseRotation = !clockwiseRotation;
}
