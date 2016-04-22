using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float AngularSpeed = 10f;


    public float JumpDistance = 1000f;
    public float JumpSpeed = 10f;
    private bool jumping = false;

    Rigidbody rigidbody;
    
    private float sum=0;
    private bool grounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        sum += moveHorizontal * AngularSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(Mathf.Sin((sum * Mathf.PI) / 180), 0.0f, Mathf.Cos((Mathf.PI * sum) / 180));

        rigidbody.velocity = movement * Speed * moveVertical;

        rigidbody.position = rigidbody.position + rigidbody.velocity * Time.deltaTime;

        rigidbody.rotation = Quaternion.Euler(0f, sum, 0f);
        

        if (Input.GetButtonDown("Jump") && grounded)
            jumping = true;

        MyJump();
    }

    private void MyJump()
    {
        if (jumping)
        {
            if (transform.position.y >= JumpDistance)
                jumping = false;
            else
                rigidbody.velocity += Vector3.up * JumpSpeed;
        }
        else if(!grounded)
            rigidbody.velocity -= Vector3.up * JumpSpeed;
    }


    void OnCollisionStay(Collision col)
    {        
        if(col.collider.tag.Equals("Floor"))
        {
            grounded = true;
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