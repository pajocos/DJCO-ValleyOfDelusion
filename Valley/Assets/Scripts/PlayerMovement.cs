using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public float Acceleration = 50f;
    public float MaxSpeed = 50f;
    public float JumpStrength = 500f;


    private bool onGround = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float xSpeed = Input.GetAxis("Horizontal");
        float zSpeed = Input.GetAxis("Vertical");

        Vector3 velocityAxis = new Vector3(xSpeed, 0, zSpeed);
        velocityAxis = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * velocityAxis;
        

	}
}
