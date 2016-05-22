using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float AngularSpeed = 10f;
    public float Gravity = 20f;

    public float JumpImpulsion = 10f;
    public float jumpSpeed = 0;

    public float Rotation = 0f;

    public float PUSHBACKTIME = 10f;
    public bool grounded = false;

    Rigidbody rgbd;

    private Vector3 internalVelocity = Vector3.zero;
    private bool lerpingBack = false;
    private float lerpTime = 0f;

    private Vector3 lerpEndPos;
    private Vector3 lerpStartPos;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }


    //turnAngle should be Hor axis
    //speedInput should be Vert Axis
    public void Move(float turnAngle, float speedInput, bool jump)
    {


        if (lerpingBack)
        {
            LerpingBack();
            //unable to jump and move
            ////NOTA: talvez possa usar uma função que use o transform position em vez de lerp
            jumpManager(false);
            movementManager(0);
            print("wut");
        }
        else
        {
            GetComponent<Animator>().SetFloat("walking", speedInput);
            GetComponent<Animator>().SetBool("isWalking", speedInput != 0);
            rotationManager(turnAngle);
            movementManager(speedInput);
            jumpManager(jump);
        }
        transform.position += internalVelocity * Time.deltaTime + Vector3.up * jumpSpeed * Time.deltaTime;

    }

    private void movementManager(float speedInput)
    {
        Vector3 movement = new Vector3(Mathf.Sin((Rotation * Mathf.PI) / 180), 0.0f, Mathf.Cos((Mathf.PI * Rotation) / 180));

        internalVelocity = movement * Speed * speedInput;
    }

    private void rotationManager(float turnAngle)
    {
        Rotation += turnAngle * AngularSpeed * Time.deltaTime;
        rgbd.rotation = Quaternion.Euler(0f, Rotation, 0f);
    }

    private void jumpManager(bool jump)
    {
        if (jump && grounded)
        {
            jumpSpeed = JumpImpulsion;

        }
        else if (!grounded)
        {
            jumpSpeed -= Gravity * Time.deltaTime;
        }
    }



    private void LerpingBack()
    {
        lerpTime += Time.deltaTime;
        //print("lerptime: "+lerpTime);
        if (lerpTime <= PUSHBACKTIME)
            transform.position = Vector3.Lerp(lerpStartPos, lerpEndPos, lerpTime / PUSHBACKTIME);
        else
            lerpingBack = false;
    }


    public void PushBack(float distance, Vector3 direction)
    {
        lerpingBack = true;
        lerpTime = 0;

        direction.Normalize();
        direction *= distance;

        lerpStartPos = transform.position;
        lerpEndPos = lerpStartPos + direction;
    }


}