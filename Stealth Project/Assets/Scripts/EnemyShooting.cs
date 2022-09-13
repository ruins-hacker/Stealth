using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Animator anim;
    private bool haveShoot = false;
    private PlayerHealth health;
    public float minDamage = 30;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetFloat("Shot") > 0.5)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if(haveShoot == false)
        {
            //º∆À„…À∫¶
            float damage = minDamage + 90 - 9 * (transform.position - health.transform.position).magnitude;
            health.TakeDamage(damage);
            haveShoot = true;
        } else
        {
            haveShoot = false;
        }


    }
}
