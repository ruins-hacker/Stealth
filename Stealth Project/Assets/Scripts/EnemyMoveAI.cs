using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveAI : MonoBehaviour
{
    public Transform[] wayPoints;
    public float patrolTime = 3f;
    public float chaseTime = 3f;
    

    private float patrolTimer = 0;
    private float chaseTimer = 0;
    private int index = 0;
    private NavMeshAgent navAgent;
    private Animator anim;
    private PlayerHealth health;

    private EnemySight sight;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        navAgent.destination = wayPoints[index].position;
        sight = GetComponent<EnemySight>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.playerInSight && health.hp >0)
        {
            Shooting();
        } else if(sight.alertPosition != Vector3.zero && health.hp > 0)
        {
            Chasing();
        } else
        {

        }
        Patrolling();
    }

    private void Patrolling()
    {
        navAgent.speed = 3;
        navAgent.destination = wayPoints[index].position;
        if(navAgent.remainingDistance < 0.5f)
        {
            navAgent.isStopped = true;
            patrolTimer += Time.deltaTime;
            if (patrolTimer > patrolTime)
            {
                navAgent.isStopped = false;
                index++;
                index = index % 4;
                navAgent.destination = wayPoints[index].position;
                patrolTimer = 0;
            }
        }
        anim.SetFloat("Speed", navAgent.velocity.magnitude);



    }

    private void Chasing()
    {
        navAgent.isStopped = false;
        navAgent.speed = 5;
        navAgent.destination = sight.alertPosition;

        if (navAgent.remainingDistance < 2f)
        {
            chaseTimer += Time.deltaTime;
            if(chaseTimer > chaseTime)
            {
                sight.alertPosition = Vector3.zero;
                GM.shared.lastPlayerPosition = Vector3.zero;
                GM.shared.alertOn = false;
            }
        }
    }

    private void Shooting()
    {
        anim.SetBool("PlayerInSight", true);
        navAgent.isStopped = true;
    }
}
