using UnityEngine;
using System.Collections;

public class GroundColliderBehaviour : MonoBehaviour {

    public PlayerBehaviour player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    

    void OnTriggerEnter(Collider col) {
        Debug.Log("Enter triggerwith floor");

        if (col.tag == "Floor") {
            Debug.Log("Enter triggerwith floor");
            player.FloorTriggerEnter();

        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Floor") {
            Debug.Log("exit trigger with floor");
            player.FloorTriggerExit();

        }
    }

    void OnTriggerStay(Collider col) {
        if (col.tag == "Floor") {
            player.FloorTriggerStay();


        }
    }

}
