using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public CharacterMovement movement;

    private int floorContacts = 0;

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
            floorContacts--;
            if (floorContacts < 0)
                floorContacts = 0;

            if (floorContacts == 0)
                movement.grounded = true;
            movement.jumpSpeed = 0;
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            floorContacts++;
            movement.grounded = false;
        }
    }
}
