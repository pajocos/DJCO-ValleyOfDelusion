using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    //private Renderer renderer;

    public AudioClip[] clips;
    public AudioSource source;

    void Start()
    {
        source.clip = clips[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.color =
        //    new Color(1.0f, 1.0f, 0.5f, 1.0f);

        if (PlayerBehaviour.gems == 0)
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 2, 0), Time.deltaTime*45f);
            if(!source.isPlaying)
            {
                int r = Random.Range(0, clips.Length - 1);
                source.clip = clips[r];
                source.Play();
            }

        }
        else if (PlayerBehaviour.gems == 1)
        {
            //fade out
        }
    }
}