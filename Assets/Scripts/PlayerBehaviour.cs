using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public CharacterMovement movement;

    private int floorContacts = 0;
    private RaycastHit hit;
    public float dist = 1f;
    private Transform transform;

    public bool canMove;

    private int gems = 0;

    // Use this for initialization
    void Start () {
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

        Debug.DrawRay(transform.position + Vector3.up, Vector3.down * dist, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down,out hit, dist)) {

            if (hit.collider.tag == "Floor") {
                if (!movement.grounded && movement.jumpSpeed < 0 ) {
                    movement.grounded = true;
                    movement.jumpSpeed = 0;

                }
            }
            
        } else {
            movement.grounded = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Gem")
        {
            gems++;
            col.collider.GetComponentInParent<SphereCollider>().enabled = false;
            col.collider.GetComponentInParent<MeshRenderer>().enabled = false;

        }
    }
        
}
