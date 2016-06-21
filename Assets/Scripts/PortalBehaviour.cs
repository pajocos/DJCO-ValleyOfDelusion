using UnityEngine;
using System.Collections;

public class PortalBehaviour : MonoBehaviour {

    public Transform Destination;
    public GameObject Player;
	
	  void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            Player.transform.position = Destination.position;

        }
      
    }
}
