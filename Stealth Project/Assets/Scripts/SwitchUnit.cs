using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUnit : MonoBehaviour
{
    private AudioSource audio;
    public GameObject lazer;
    public Material unlockMat;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("12");
        if(other.tag == Tags.player)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                lazer.SetActive(false);
                audio.Play();
                screen.GetComponent<MeshRenderer>().material = unlockMat;
            }


        }
    }
}
