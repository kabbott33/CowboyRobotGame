using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefense : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float fireRate = 1f;

    private float fireCountdown = 0f;

    void Update()
    {
        AimAndFire();


    }

    void AimAndFire()
    {
        // Get mouse position in world coordinates
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y; 


            transform.LookAt(targetPosition);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Fire in the direction the tower is facing
            rb.velocity = firePoint.forward * projectileSpeed;
        }

    }
}
