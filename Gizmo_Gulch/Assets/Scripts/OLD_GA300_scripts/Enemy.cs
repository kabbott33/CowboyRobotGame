using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject target;
    private Animator AnimEnemy;

    private float currentAttackTimer;
    public float attackTimerInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = this.GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.transform.position);
        float Speed = enemy.velocity.z;
        AnimEnemy.SetFloat("Speed", Mathf.Abs(enemy.velocity.magnitude));
        if(enemy.remainingDistance <= enemy.stoppingDistance)
        {
            AnimEnemy.SetBool("CanAttack", true);
                  
        }
        else
        {
            AnimEnemy.SetBool("CanAttack", false);
        }
    }

    public void Attack()
    {
        Debug.LogError("PLAYER ATTACKED");
    }
}

