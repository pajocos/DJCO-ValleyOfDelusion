using UnityEngine;
using System.Collections;

public class AttackColliderScript : MonoBehaviour {

    public PlayerBehaviour Player;

    BoxCollider coli;
	// Use this for initialization
	void Start () {
        coli = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.collider.tag.Equals("Player"))
    //    {
    //        Player.movement.PushBack(10, transform.forward);
    //        coli.enabled = false;
    //    }
    //}
}
