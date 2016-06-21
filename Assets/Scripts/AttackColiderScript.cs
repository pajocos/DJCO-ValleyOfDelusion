using UnityEngine;
using System.Collections;
using Assets.Scripts;


public class AttackColiderScript : MonoBehaviour {
    public FixedEnemyBehavior mainscript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {

        
        if (col.tag == ("Player")) {
            mainscript.TriggerWithPlayer();
        }
    }
    void OnTriggerExit(Collider col) {
        Debug.Log("trigger exit");

        if (col.tag == ("Player")) {
            mainscript.StopAttack();
        }


    }
}
