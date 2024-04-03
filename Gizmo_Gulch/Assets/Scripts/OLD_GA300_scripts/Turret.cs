using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public static Turret instance;
    public GameObject shotEffect;
    public GameObject firePoint;
    public GameObject bullet;


    public float fireRate = 1f;
    private float currentFire;

    public TMP_Text killCount;
  
    public int killerNumber;

    public Slider healthBar;
    public int Health = 100;

    public GameObject bomb;
    void Start()
    {
        instance = this;
        healthBar.value = Health;
    }

    public void AddKill()
    {
        killerNumber = killerNumber + 1;
        killCount.text = killerNumber.ToString();
    }

    public void ReduceHealth(int Dmg)
    {
        Health = Health - Dmg;
        healthBar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

 

    void Aim()
    {
        Ray aim = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(aim, out hit))
        {
            Debug.DrawRay(aim.origin, hit.point, Color.red);
            Vector3 hitpos = hit.point;
            hitpos.y = 0f;

            this.transform.LookAt(hitpos);

            currentFire += Time.unscaledDeltaTime;

            if(Input.GetKey(KeyCode.Mouse0) && currentFire >= fireRate)
            {
                Fire();
                currentFire = 0;
            }

            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
                Bomb(hit.point);
            }
        }
    }

    void Fire()
    {
        GameObject GO = Instantiate(shotEffect, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(GO, 1.5f);
        GameObject bulletGO = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    void Bomb(Vector3 bombPoint)
    {
        GameObject GO = Instantiate(bomb, Camera.main.transform.position, Camera.main.transform.rotation);
        GO.transform.LookAt(bombPoint);
    }
}
