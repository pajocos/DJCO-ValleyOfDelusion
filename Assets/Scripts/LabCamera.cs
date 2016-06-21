using UnityEngine;
using System.Collections;

public class LabCamera : MonoBehaviour
{
    public float height = 50;
    public Transform playerTransform;
    private Vector3 pos;

    void Start ()
    {
        pos = playerTransform.position;
        transform.position = new Vector3(pos.x, pos.y + height , pos.z);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + height, playerTransform.position.z);
    }
}
