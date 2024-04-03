using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public Rigidbody rb;
    private Animator Anim;
    public float speed;
    public float sprintspeed;
    public float walkspeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public float groundCheckValue;
    public GameObject rayCastObject;

    private float horizontal;
    private float vertical;
    private bool isFacingRight;
    private bool OnFloor;
    public bool isGrounded = false;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Anim = this.GetComponent<Animator>();
    }
  

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
        GroundCheck();
    }

    private void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void GroundCheck()
    {
        if (Physics.Raycast(rayCastObject.transform.position, Vector3.down, groundCheckValue, groundLayer))
        {
            if (isGrounded == false)
            {
                Anim.SetBool("Jump", false);
            }
            isGrounded = true;
        }
        else
            isGrounded = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3(horizontal * Time.deltaTime * sprintspeed, rb.velocity.y, rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(horizontal * Time.deltaTime * walkspeed, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(horizontal * Time.deltaTime * speed, rb.velocity.y, rb.velocity.z);
        }

        float newHori = horizontal;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            newHori = horizontal * 2;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            newHori = horizontal * 0.8f;
        }
        Anim.SetFloat("Speed", Mathf.Abs(newHori));
        Rotate();
    }

    private void Rotate()
    {
        if(horizontal > 0 && !isFacingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            isFacingRight = true;
        }
        else if(horizontal < 0 && isFacingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            isFacingRight = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Anim.SetBool("Jump", true);
        }
        
    }
}

