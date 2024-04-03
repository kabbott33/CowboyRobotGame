using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public Rigidbody rb;

    private float vertical;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (vertical > 0.5)
        {
            CameraController.instance.SwitchCamera(CameraStates.speed);
        }
        else
        {
            CameraController.instance.SwitchCamera(CameraStates.Main);
        }
    }

    private void Update()
    {
        GetInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // For moving the player
        PlayerMove();

        // For rotation
        PlayerRotate();

        Debug.LogError("vertical :: " + vertical);

    }

    private void PlayerMove()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, 0f, vertical * Time.fixedDeltaTime);

        movement = transform.TransformDirection(movement);

        // move the object
        //rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        rb.AddForce(movement * speed, ForceMode.Acceleration);


    }

    private void PlayerRotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate rotation
        float rotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;

        // rotate the object based on input
        // vector3 = 1,0,0 // coords

        transform.Rotate(Vector3.up, rotation);
    }
}
