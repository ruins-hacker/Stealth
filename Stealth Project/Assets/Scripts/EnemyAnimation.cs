using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public float speedDampTime = 0.3f;
    public float angleDampTime = 0.3f;
    private NavMeshAgent navAgent;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //期望达到的速度
        if(navAgent.desiredVelocity  == Vector3.zero)
        {
            Debug.Log("test");
            anim.SetFloat("Speed", 0);
            anim.SetFloat("AnglarSpeed", 0);
        } else
        {
            float angle = Vector3.Angle(transform.forward, navAgent.desiredVelocity);
            float angleRad = 0f;
            //if(angle > 90)
            //{
            //    Debug.Log("dayu90");
            //    //anim.SetFloat("Speed", 0);
            //} else
            //{
            //    Debug.Log("xiaoyu90");
            //    Vector3 projection = Vector3.Project(navAgent.desiredVelocity, transform.forward);
            //    anim.SetFloat("Speed",projection.magnitude);
            //    //anim.SetFloat("Speed", 30f, speedDampTime, Time.deltaTime);

            //}
            Vector3 projection = Vector3.Project(navAgent.desiredVelocity, transform.forward);
            anim.SetFloat("Speed", projection.magnitude * 1.2f);
            angleRad = angle * Mathf.Deg2Rad;
            Vector3 crossRes = Vector3.Cross(transform.forward, navAgent.desiredVelocity);
            if(crossRes.y < 0)
            {
                //左移动
                angleRad = -angleRad;
            }

            anim.SetFloat("AnglarSpeed", angleRad * 8);
        }
    }
}
