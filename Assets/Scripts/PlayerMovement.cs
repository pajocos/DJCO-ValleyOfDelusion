using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float AngularSpeed = 10f;
    public float Gravity = 10f;

    public float JumpImpulsion = 10f;
    public float jumpSpeed = 0;

    private Vector3 internalVelocity = Vector3.zero;


    Rigidbody rigidbody;
    
    private float sum=0;
    public bool grounded = false;

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
        }
    }


   
}