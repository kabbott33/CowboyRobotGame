using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody rb;
    public float projectileSpeed = 2;
    public float Radius = 5f;
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
        if(other.gameObject.tag == "Ground")
        {
            RaycastHit[] allhits = Physics.SphereCastAll(this.transform.position, Radius, this.transform.position);

            foreach(RaycastHit hit in allhits)
            {
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
