using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

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

        GetComponent<Rigidbody>().AddForce(velocityAxis.normalized * Acceleration);

        onGround = CheckGroundCollision();

        if (Input.GetButtonDown("Jump"))
            Jump();

        

	}


    private bool CheckGroundCollision()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Collision");


        Bounds meshBounds = GetComponent<MeshFilter>().mesh.bounds;

        if (Physics.Raycast(transform.position + meshBounds.center, Vector3.down, meshBounds.extents.y, layerMask))
            return true;


        return false;
    }

    private void Jump()
    {
        if(onGround)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrength, 0));
        }
            
    }



}
