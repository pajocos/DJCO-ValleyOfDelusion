using UnityEngine;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour {
    public float RunningSpeed = 10f;
    public float WalkingSpeed = 5f;
    public float AngularSpeed = 10f;
    public float Gravity = 20f;

    public float JumpImpulsion = 10f;
    public float jumpSpeed = 0;

    public float Rotation = 0f;

    public float PUSHBACKTIME = 10f;
    public bool grounded = false;
    public bool canJump = false;
    Rigidbody rgbd;

    public Vector3 internalVelocity = Vector3.zero;
    private bool lerpingBack = false;
    private float lerpTime = 0f;


    private Vector3 lerpEndPos;
    private Vector3 lerpStartPos;

    void Start() {
        rgbd = GetComponent<Rigidbody>();
    }


    //turnAngle should be Hor axis
    //speedInput should be Vert Axis
    public void Move(float turnAngle, float speedInput, bool jump, bool run) {

        if (lerpingBack) {
            LerpingBack();
            //unable to jump and move
            jumpManager(false);
            movementManager(0, run);
        } else {
            GetComponent<Animator>().SetBool("IsWalking", speedInput != 0);
            rotationManager(turnAngle);
            movementManager(speedInput, run);
            jumpManager(jump);
        }
        transform.position += internalVelocity * Time.deltaTime + Vector3.up * jumpSpeed * Time.deltaTime;

        rgbd.velocity = Vector3.zero;
        rgbd.angularVelocity = Vector3.zero;

    }

    internal void GetUp() {
        
            GetComponent<Animator>().SetBool("Crouched",false);
        
    }

    internal void Crouch() {
        GetComponent<Animator>().SetBool("IsWalking", false);
        GetComponent<Animator>().SetBool("Crouched",true);
        

    }

    private void movementManager(float speedInput, bool run) {
        Vector3 movement = new Vector3(Mathf.Sin((Rotation * Mathf.PI) / 180), 0.0f, Mathf.Cos((Mathf.PI * Rotation) / 180));

        if (!run) {

            GetComponent<Animator>().SetFloat("WalkMulti", 2f);
            GetComponent<Animator>().SetFloat("Speed", 0.5f);
            internalVelocity = movement * WalkingSpeed * speedInput;
        } else {

            GetComponent<Animator>().SetFloat("WalkMulti", 1f);
            GetComponent<Animator>().SetFloat("Speed", 1f);
            internalVelocity = movement * RunningSpeed * speedInput;
        }

    }

    private void rotationManager(float turnAngle) {
        Rotation += turnAngle * AngularSpeed * Time.deltaTime;
        rgbd.rotation = Quaternion.Euler(0f, Rotation, 0f);
    }

    private void jumpManager(bool jump) {
        if (jump && grounded && canJump) {
            jumpSpeed = JumpImpulsion;
            GetComponent<Animator>().SetTrigger("Jump");
        } else if (!grounded) {
            jumpSpeed -= Gravity * Time.deltaTime;
        }
    }



    private void LerpingBack() {
        lerpTime += Time.deltaTime;
        //print("lerptime: "+lerpTime);
        if (lerpTime <= PUSHBACKTIME)
            transform.position = Vector3.Lerp(lerpStartPos, lerpEndPos, lerpTime / PUSHBACKTIME);
        else {
            lerpingBack = false;
        }
    }


    public void PushBack(float distance, Vector3 direction) {
        lerpingBack = true;
        GetComponent<Animator>().SetTrigger("KnockBack");

        lerpTime = 0;

        direction.Normalize();
        direction *= distance;

        lerpStartPos = transform.position;
        lerpEndPos = lerpStartPos + direction;
    }


}