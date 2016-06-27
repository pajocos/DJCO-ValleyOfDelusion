using UnityEngine;
using System.Collections;

public class PendulumReproducerScript : MonoBehaviour
{

    private AudioSource pendulumSound;

    void Start()
    {
        pendulumSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "MusicDetector" && !pendulumSound.isPlaying)
        {
            pendulumSound.Play();
        }
    }
}
