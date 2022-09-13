using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cctvCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("cctv1");
        if(other.tag == Tags.player)
        {
            Debug.Log("cctv2");
            GM.shared.alertOn = true;
            GM.shared.lastPlayerPosition = other.transform.position;
        }
    }
}
