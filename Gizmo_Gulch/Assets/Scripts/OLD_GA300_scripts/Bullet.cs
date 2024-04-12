using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float projectileSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = this.transform.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Turret.instance.AddKill();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        // Destroy the bullet
        // Destroy the Spider
    }

}
