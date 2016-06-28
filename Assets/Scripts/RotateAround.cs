using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    //private Renderer renderer;

    void Start()
    {
        //renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.color =
        //    new Color(1.0f, 1.0f, 0.5f, 1.0f);

        if (PlayerBehaviour.gems == 0)
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 2, 0), Time.deltaTime*45f);
        }
        else if (PlayerBehaviour.gems == 1)
        {
            //fade out
        }
    }
}