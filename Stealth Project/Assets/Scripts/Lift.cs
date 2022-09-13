using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform outerLeftDoor;
    public Transform outerRightDoor;
    public Transform innerLeftDoor;
    public Transform innerRightDoor;
    public float moveSpeed = 3;
    public float liftUpTime = 3;
    private float liftUpTimer = 0;
    private bool isIn = false;
    private float gameWinTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float innerLeftDoorX = Mathf.Lerp(innerLeftDoor.position.x, outerLeftDoor.position.x, Time.deltaTime * moveSpeed);
        innerLeftDoor.position = new Vector3(innerLeftDoorX, innerLeftDoor.position.y, innerLeftDoor.position.z);
        float innerRightDoorX = Mathf.Lerp(innerRightDoor.position.x, outerRightDoor.position.x, Time.deltaTime * moveSpeed);
        innerRightDoor.position = new Vector3(innerRightDoorX, innerRightDoor.position.y, innerRightDoor.position.z);
        if(isIn)
        {
            liftUpTimer += Time.deltaTime;
            if(liftUpTimer > liftUpTime)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
                gameWinTimer += Time.deltaTime;
                if(gameWinTimer > 2)
                {
                    GM.WinGame();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player)
        {
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isIn = false;
            liftUpTimer = 0;
        }
    }
}
