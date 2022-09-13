using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator ani;
    private int speedId = Animator.StringToHash("Speed");
    private int sneakId = Animator.StringToHash("Sneak");
    public bool hasKey = false;
    public float moveSpeed = 4;
    public float rotateSpeed = 0;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ani.SetBool(sneakId, true);
        } else
        {
            ani.SetBool(sneakId, false);
        }

        if(Mathf.Abs(h) > 0.1|| Mathf.Abs(v) > 0.1)
        {

            //transform.position = transform.forward * moveSpeed * Time.deltaTime;


            float newSpeed = Mathf.Lerp(ani.GetFloat(speedId), 5.6f, Time.deltaTime * moveSpeed);
            ani.SetFloat(speedId, newSpeed);

            Vector3 targetDir = new Vector3(h, 0, v);
            //transform.position += transform.forward * targetDir.magnitude * moveSpeed * Time.deltaTime;

            Quaternion newRotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotateSpeed);
            //ani.SetFloat(speedId, targetDir.magnitude * moveSpeed);


            if ( ani.GetCurrentAnimatorStateInfo(0).IsName("Locomation"))
            {
                if(!audio.isPlaying)
                {
                    audio.Play();
                }
               
            } else
            {
                if(audio.isPlaying)
                {
                    audio.Stop();
                }
            }

        } else
        {
            ani.SetFloat(speedId, 0);
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }


    }
}
