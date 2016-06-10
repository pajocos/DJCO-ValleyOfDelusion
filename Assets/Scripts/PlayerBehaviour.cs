using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public Collider groundCollider;
    public CharacterMovement movement;

    private int floorContacts = 0;
    private RaycastHit hit;
    public float dist = 1f;
    private Transform transform;

    public bool canMove;

    private int gems = 0;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        transform = GetComponent<Transform>();

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


    public int getGems()
    {
        return gems;
    }

}



