using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public Collider groundCollider;
    public CharacterMovement movement;

    private int floorContacts = 0;
    private RaycastHit hit;
    public float dist = 1f;

    public bool canMove;

    private bool alive;
    private int gems;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        gems = 0;
        alive = true;
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            bool jump = Input.GetButtonDown("Jump");
            movement.Move(moveHorizontal, moveVertical, jump);
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Gem")
        {
            gems++;
            col.collider.GetComponentInParent<SphereCollider>().enabled = false;
            col.collider.GetComponentInParent<MeshRenderer>().enabled = false;

        }
        
        if (col.collider.tag == "Floor")
        {
            foreach (ContactPoint c in col.contacts)
            {
                if(c.thisCollider == groundCollider)
                {
                    movement.grounded = true;
                    movement.jumpSpeed = 0;
                    break;
                }
            }
        }
    }


    void OnCollisionStay(Collision col)
    {   

        if (col.collider.tag == "Floor")
        {
            foreach (ContactPoint c in col.contacts)
            {
                if (c.thisCollider == groundCollider)
                {
                    movement.grounded = true;
                    movement.jumpSpeed = 0;
                    break;
                }
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            movement.grounded = false;
        }
    }


    public int GetGems()
    {
        return gems;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void Kill()
    {
        alive = false;
    }

}



