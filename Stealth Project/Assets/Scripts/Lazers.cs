using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazers : MonoBehaviour
{
    public float onTime = 3;
    public float offTime = 3;
    public bool isFlicker = false;
    private float timer = 0;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlicker)
        {
            timer += Time.deltaTime;
            if(mesh.enabled)
            {
                if(timer >= onTime)
                {
                    mesh.enabled = false;
                    timer = 0;
                }
            }

            if(!mesh.enabled)
            {
                if(timer >= offTime)
                {
                    mesh.enabled = true;
                    timer = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player && mesh.enabled)
        {
            Debug.Log("´¥·¢¾¯¸æ");
            GM.shared.alertOn = true;
            GM.shared.lastPlayerPosition = other.transform.position;
        }
    }
}
