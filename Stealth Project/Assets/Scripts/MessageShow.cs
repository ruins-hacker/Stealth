 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageShow : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "WASD to Move\nZ to Switch\nShift to Sneak";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
