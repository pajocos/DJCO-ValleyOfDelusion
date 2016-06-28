using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {
    public CharacterMovement movement;
    public MusicScript musicManager;
    public float dist = 1f;
    public Image[] canvasGems;

    public GameObject portal1;
    public GameObject portal2;

    static public Vector3 StartPosition;

    public bool canMove;

    //if his speed is greater than MaxSpeed, the player dies
    public float MaxJumpSpeed = 100f;

    private bool alive;
    static public int gems = 0;

    // Use this for initialization
    void Start() {
        movement = GetComponent<CharacterMovement>();
        gems = 5;
        alive = true;
        canMove = true;

        if (StartPosition != Vector3.zero)
            transform.position = StartPosition;

    }

    internal void FloorTriggerEnter() {
        movement.canJump = true;
    }

    internal void FloorTriggerExit() {
        movement.canJump = false;

    }

    internal void FloorTriggerStay() {
        movement.canJump = true;

    }

    void Died()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!alive)
        {
            //animação de morte!!!
            //som de morte
            //mostrar qualquer coisa no ecra

            Invoke("Died", 2.5f);
            return;
        }
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

    IEnumerator delayWrapper(Collision col, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);


        col.collider.GetComponentInParent<SphereCollider>().enabled = false;
        col.collider.GetComponentInParent<MeshRenderer>().enabled = false;
    }


    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Gem") {
            gems++;

            Debug.Log(gems);


            GetComponent<Animator>().SetTrigger("Capture");
            musicManager.GemSound();

            canvasGems[(gems - 1)].enabled = true;
            float t = 0;
            print(t);
            StartCoroutine(delayWrapper(col,0.5f));
        }

        if (col.collider.tag == "Floor") {

            movement.grounded = true;
            movement.jumpSpeed = 0;
            GetComponent<Animator>().SetBool("Midair", false);
            GetComponent<Animator>().SetTrigger("Land");

            musicManager.LandSound();
        }

        if (col.collider.tag == "Ball")
        {
            Kill();
        }
    }


    void OnCollisionStay(Collision col) {
        if (col.collider.tag == "Floor") {

            movement.grounded = true;
            movement.jumpSpeed = 0;
            GetComponent<Animator>().SetBool("Midair",false);
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
        if(col.tag == "MusicDetector")
        {
            musicManager.changeMusicAndEnvironment(col);
        }
        if (col.tag == "CountCristal")
        {
            Debug.Log(PlayerBehaviour.gems);
            if (gems == 5)
            {
                portal1.SetActive(true);
                portal2.SetActive(true);
            }
            else
            {
                Debug.Log("catch more gems");
            }
        }
    }

    public int GetGems() {
        return gems;
    }

    public bool IsAlive() {
        return alive;
    }

    public void Kill() {
        alive = false;
        musicManager.DefeatSound();
        GetComponent<Animator>().SetTrigger("Death");

    }
    public void StepSound(string ident) {
        musicManager.StepSound(ident);
    }



}