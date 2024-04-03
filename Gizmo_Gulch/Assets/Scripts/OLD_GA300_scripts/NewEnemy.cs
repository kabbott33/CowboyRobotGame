using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject target;
    private Animator AnimEnemy;

    public float AttackInterval;
    private float currentTimer;

    public int Damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = this.GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        target = Turret.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.transform.position);
        float Speed = enemy.velocity.z;
        AnimEnemy.SetFloat("Speed", Mathf.Abs(enemy.velocity.magnitude));
        if (enemy.remainingDistance <= enemy.stoppingDistance)
        {
            AnimEnemy.SetBool("CanAttack", true);
            currentTimer += Time.unscaledDeltaTime;

            if(currentTimer >= AttackInterval)
            {
                Attack();
                currentTimer = 0f;
            }
        }
        else
        {
            AnimEnemy.SetBool("CanAttack", false);
        }
    }

    public void Attack()
    {
        Turret.instance.ReduceHealth(Damage);
    }
}

