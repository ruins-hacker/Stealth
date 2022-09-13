using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;
    public float moveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        offset = new Vector3(0, offset.y, offset.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 beginPos = offset + player.position;
        Vector3 endPos = player.position + offset.magnitude * Vector3.up;

        Vector3 pos1 = Vector3.Lerp(beginPos, endPos, 0.25f);
        Vector3 pos2 = Vector3.Lerp(beginPos, endPos, 0.5f);
        Vector3 pos3 = Vector3.Lerp(beginPos, endPos, 0.75f);

        Vector3[] posArray = new Vector3[] { beginPos, pos1, pos2, pos3, endPos };
        Vector3 targetPos = posArray[0];

        foreach(var pos in posArray)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(pos, (player.position - pos), out hitInfo))
            {
                if (hitInfo.collider.tag != Tags.player)
                {
                    continue;
                }
                else
                {
                    targetPos = pos;
                    break;
                }
            } else
            {
                targetPos = pos;
                break;
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
        Quaternion nowRotation = transform.rotation;
        transform.LookAt(player.position);

        transform.rotation = Quaternion.Lerp(nowRotation, transform.rotation, Time.deltaTime * rotateSpeed);
        
    }
}
