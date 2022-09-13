using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("card");
        if(other.tag == Tags.player)
        {
            Player player = other.GetComponent<Player>();
            player.hasKey = true;
            AudioSource.PlayClipAtPoint(clip, other.transform.position);
            Destroy(this.gameObject);
        }
    }
}
