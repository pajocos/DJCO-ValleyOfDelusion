using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private PlayerMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<PlayerMovement>();
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        movement.Move(moveHorizontal, moveVertical, jump);

    }
}
