using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public CharacterMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<CharacterMovement>();
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        movement.Move(moveHorizontal, moveVertical, jump);

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag.Equals("Floor"))
        {
            movement.grounded = true;
            movement.jumpSpeed = 0;
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            movement.grounded = false;
        }
    }
}
