using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
    public Collider groundCollider;
    public CharacterMovement movement;
    public MusicScript musicManager;
    public float dist = 1f;

    public bool canMove;

    //if his speed is greater than MaxSpeed, the player dies
    public float MaxJumpSpeed = 100f;

    private bool alive;
    private int gems;

    // Use this for initialization
    void Start() {
        movement = GetComponent<CharacterMovement>();
        gems = 0;
        alive = true;
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Mathf.Abs(movement.jumpSpeed) > MaxJumpSpeed)
            Kill();


        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            canMove = false;
            movement.Crouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            canMove = true;
            movement.GetUp();
        }


        if (canMove) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            bool jump = Input.GetButtonDown("Jump");
            bool run = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            movement.Move(moveHorizontal, moveVertical, jump, run);
        }
    }


    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Gem") {
            gems++;
            col.collider.GetComponentInParent<SphereCollider>().enabled = false;
            col.collider.GetComponentInParent<MeshRenderer>().enabled = false;

        }

        if (col.collider.tag == "Floor") {
            foreach (ContactPoint c in col.contacts) {
                if (c.thisCollider == groundCollider) {
                    movement.grounded = true;
                    movement.jumpSpeed = 0;
                    break;
                }
            }
        }
    }


    void OnCollisionStay(Collision col) {
        if (col.collider.tag == "Floor") {
            foreach (ContactPoint c in col.contacts) {
                if (c.thisCollider == groundCollider) {
                    movement.grounded = true;
                    movement.jumpSpeed = 0;
                    break;
                }
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.collider.tag == "Floor") {
            movement.grounded = false;
        }
    }



    void OnTriggerEnter(Collider col) {
        if (col.tag == "Water") {
            Kill();
        }
    }

    public int GetGems() {
        return gems;
    }

    public bool IsAlive() {
        return alive;
    }

    public void Kill() {
        print("dead");
        alive = false;
    }
    public void StepSound(string ident) {
        musicManager.StepSound(ident);
    }



}