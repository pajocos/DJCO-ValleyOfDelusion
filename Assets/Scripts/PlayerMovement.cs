using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float AngularSpeed = 10f;
    public float Gravity = 10f;

    public float JumpImpulsion = 10f;
    private float jumpSpeed = 0;

    private Vector3 internalVelocity = Vector3.zero;


    Rigidbody rigidbody;
    
    private float sum=0;
    private bool grounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    //turnAngle should be Hor axis
    //speedInput should be Vert Axis
    public void Move(float turnAngle, float speedInput, bool jump)
    {
        rotationManager(turnAngle);
        movementManager(speedInput);
        jumpManager(jump);

        transform.position += internalVelocity * Time.deltaTime + Vector3.up * jumpSpeed * Time.deltaTime;
           
    }

    private void movementManager(float speedInput)
    {
        Vector3 movement = new Vector3(Mathf.Sin((sum * Mathf.PI) / 180), 0.0f, Mathf.Cos((Mathf.PI * sum) / 180));

        internalVelocity = movement * Speed * speedInput;
    }

    private void rotationManager(float turnAngle)
    {
        sum += turnAngle * AngularSpeed * Time.deltaTime;
        rigidbody.rotation = Quaternion.Euler(0f, sum, 0f);
    }

    private void jumpManager(bool jump)
    {
        if (jump && grounded)
        {
            jumpSpeed = JumpImpulsion;
        }
        if (!grounded)
        {
            jumpSpeed -= Gravity * Time.deltaTime;         
            //if(internalVelocity.y > 0)
            //{
            //    Vector3 ground = transform.position;
            //    Vector3 maxH = transform.position;
            //    ground.y = 0;
            //    maxH.y = JumpSpeed;

            //    Vector3.Lerp(ground, maxH, internalVelocity.y / JumpSpeed);
            //}
        }
    }


    void OnCollisionEnter(Collision col)
    {        
        if(col.collider.tag.Equals("Floor"))
        {
            grounded = true;
            jumpSpeed = 0;
        }
    }    


    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            grounded = false;
        }
    }
}