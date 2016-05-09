using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float AngularSpeed = 10f;
    public float Gravity = 10f;

    public float JumpSpeed = 10f;

    private Vector3 internalVelocity = Vector3.zero;


    Rigidbody rigidbody;
    
    private float sum=0;
    private bool grounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
    }

    public void Move(float turnAngle, float speedInput, bool jump)
    {
        rotationManager(turnAngle);
        movementManager(speedInput);
        jumpManager(jump);
        

        rigidbody.position = rigidbody.position + internalVelocity * Time.deltaTime;
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
            internalVelocity += Vector3.up * JumpSpeed;

        }
        if (!grounded)
            internalVelocity -= Vector3.up* Gravity * Time.deltaTime;
    }


    void OnCollisionStay(Collision col)
    {        
        if(col.collider.tag.Equals("Floor"))
        {
            grounded = true;
            internalVelocity = Vector3.zero;
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