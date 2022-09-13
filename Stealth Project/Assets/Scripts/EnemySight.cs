using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    public bool playerInSight = false;
    public float fieldOfView = 110;
    public Vector3 alertPosition = Vector3.zero;

    private Animator playerAnim;
    private NavMeshAgent navAgent;
    private SphereCollider collder;
    private Vector3 preLastPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim =  GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        collder = GetComponent<SphereCollider>();
        preLastPlayerPosition = GM.shared.lastPlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.shared.lastPlayerPosition != preLastPlayerPosition)
        {
            alertPosition = GM.shared.lastPlayerPosition;


            preLastPlayerPosition = GM.shared.lastPlayerPosition;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Tags.player)
        {
            Vector3 forward = transform.forward;
            Vector3 playerDir = other.transform.position - transform.position;
            float temp = Vector3.Angle(forward, playerDir);
            RaycastHit hitInfo;
            bool res = Physics.Raycast(transform.position + Vector3.up, other.transform.position - transform.position, out hitInfo);

            if (temp < 0.5f * fieldOfView && (res == false || hitInfo.collider.tag == Tags.player)) 
            {
                playerInSight = true;
                alertPosition = other.transform.position;
                GM.shared.alertOn = true;
                GM.shared.lastPlayerPosition = other.transform.position;
            } else
            {
                playerInSight = false;
            }

            if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Locomation"))
            {
                NavMeshPath path = new NavMeshPath();
                if(navAgent.CalculatePath(other.transform.position, path))
                {
                    Vector3[] wayPoints = new Vector3[path.corners.Length + 2];
                    wayPoints[0] = transform.position;
                    wayPoints[path.corners.Length - 1] = other.transform.position;
                    for(int i = 0;i < path.corners.Length; i++)
                    {
                        wayPoints[i + 1] = path.corners[i];
                    }
                    float length = 0;
                    for(int i = 1;i < wayPoints.Length;i++)
                    {
                        length += (wayPoints[i] - wayPoints[i - 1]).magnitude;
                    }

                    if (length < collder.radius)
                    {
                        alertPosition = other.transform.position;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == Tags.player)
        {
            playerInSight = false;
        }
    }
}
