using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool requiredKey = false;
    public AudioSource musicDenied;
    private int count = 0;
    private Animator ani;
    private int isDoorOpenId = Animator.StringToHash("isOpen");
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool(isDoorOpenId, count > 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (requiredKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.hasKey)
                {
                    count++;
                }
                else
                {
                    musicDenied.Play();
                }
            }
        } else
        {
            if (other.tag == Tags.player || other.tag == Tags.enemy)
            {
                count++;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (requiredKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.hasKey)
                {
                    count--;
                }
            }
        }
        else
        {
            if (other.tag == Tags.player || other.tag == Tags.enemy)
            {
                count--;
            }
        }
    }
}
