using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cube : MonoBehaviour
{
    public float moveSpeed;
    private float playerMove;

    private float forward;
    private float side;

    private Vector3 movement;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }


    private void PlayerMovement()
    {
        this.transform.Translate(movement * Time.deltaTime * playerMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            score += other.GetComponent<Coin>().coinValue;
            Debug.Log(score);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        //}

        //if (Input.GetKey(KeyCode.S)) 
        //{
        //    this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        //}

        forward = Input.GetAxis("Horizontal");
        side = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerMove = moveSpeed * 3f;
        }
        else
        {
            playerMove = moveSpeed;
        }

        movement = new Vector3(forward, 0f, side);

        PlayerMovement();

    }

}
