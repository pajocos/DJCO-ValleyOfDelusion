using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayerBehaviour.gems == 0)
        {
            transform.RotateAround(transform.position, Vector3.zero, Time.deltaTime*90f);
        }
        else if (PlayerBehaviour.gems == 1)
        {
            //fade out
        }
    }
}