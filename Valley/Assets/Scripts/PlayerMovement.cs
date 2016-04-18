using UnityEngine;
using System.Collections;

//public class PlayerMovement : MonoBehaviour {

//    public float Acceleration = 20f;
//    public float MaxSpeed = 50f;
//    public float JumpStrength = 500f;
//    public float turnSmoothing = 15f;   // A smoothing value for turning the player.
//    public float speedDampTime = 0.1f;  // The damping for the speed parameter

//    private Rigidbody rgBody;

//    private bool onGround = true;

//	// Use this for initialization
//	void Start () {
//        rgBody = GetComponent<Rigidbody>();
//    }

//	// Update is called once per frame
//	void FixedUpdate () {

//        float xSpeed = Input.GetAxis("Horizontal");
//        float zSpeed = Input.GetAxis("Vertical");

//        MovementManager(xSpeed, zSpeed);

//        if (Input.GetButtonDown("Jump"))
//            Jump();





//	}

//    private void MovementManager(float xSpeed, float zSpeed )
//    {

//        Vector3 velocityAxis = new Vector3(0, 0, zSpeed);
//        velocityAxis = Quaternion.AngleAxis(xSpeed, Vector3.up) * velocityAxis;
//        Rotating(xSpeed + rgBody.rotation.x, 0);
//        rgBody.AddForce(velocityAxis.normalized * Acceleration);

//        onGround = CheckGroundCollision();


//    }

//    void Rotating(float horizontal, float vertical)
//    {
//        // Create a new vector of the horizontal and vertical inputs.
//        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

//        // Create a rotation based on this new vector assuming that up is the global y axis.
//        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

//        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
//        Quaternion newRotation = Quaternion.Lerp(rgBody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

//        // Change the players rotation to this new rotation.
//        rgBody.MoveRotation(newRotation);
//    }


//    private bool CheckGroundCollision()
//    {
//        int layerMask = 1 << LayerMask.NameToLayer("Collision");


//        Bounds meshBounds = GetComponent<MeshFilter>().mesh.bounds;

//        if (Physics.Raycast(transform.position + meshBounds.center, Vector3.down, meshBounds.extents.y, layerMask))
//            return true;


//        return false;
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        if(collision.collider.tag == "Floor")
//        {
//            print("co");
//            onGround = true;
//        }

//    }

//    void OnCollisionExit(Collision collision)
//    {
//        if (collision.collider.tag == "Floor")
//        {
//            print("exit");
//           onGround = false;
//        }

//    }

//    private void Jump()
//    {
//        if(onGround)
//        {
//            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrength, 0));            
//        }

//    }



//}

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float tilt;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = rigidbody.position + rigidbody.velocity * Time.deltaTime;

        rigidbody.rotation = Quaternion.Euler(moveHorizontal, moveHorizontal, moveHorizontal);
    }
}