using UnityEngine;
using System.Collections;

public class PendulumReproducerScript : MonoBehaviour
{
    public AudioClip[] PendulumSounds;
    private AudioSource sound;
    public float PitchRange = 0.2f;

    void Start()
    {
        sound = gameObject.AddComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        int r = Random.Range(0,PendulumSounds.Length-1);
        PendulumSounds[r].LoadAudioData();
        sound.clip = PendulumSounds[r];
        sound.pitch = 1.0f +(Random.value * 2 * PitchRange) - PitchRange;
        if(col.tag == "MusicDetector" && !sound.isPlaying)
        {
            sound.Play();
        }
    }
}
