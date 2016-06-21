using UnityEngine;
using System.Collections;

public class GroundColliderBehaviour : MonoBehaviour {

    public PlayerBehaviour player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Floor") {
            Debug.Log("Enter triggerwith floor");
            player.onGroundColisionEnter();
                 
            
        }
    }
}
