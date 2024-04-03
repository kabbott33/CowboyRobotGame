using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
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
       //Jump();
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

        
        rb.velocity = new Vector3(horizontal * Time.deltaTime * speed, rb.velocity.y, vertical * Time.deltaTime * speed);
        

        Anim.SetFloat("xVelocity", horizontal);
        Anim.SetFloat("yVelocity", Mathf.Abs(vertical));
        // Rotate();
    }

    private void Rotate()
    {
        if (horizontal > 0 && !isFacingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            isFacingRight = true;
        }
        else if (horizontal < 0 && isFacingRight)
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
