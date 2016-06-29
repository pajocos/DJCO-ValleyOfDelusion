using UnityEngine;
using System.Collections;

public class WaterFallBehaviour : MonoBehaviour {

    public float delayTime = 9f;
    public AudioSource DelaySound;
	// Use this for initialization
	void Awake () {
        DelaySound.PlayDelayed(delayTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
