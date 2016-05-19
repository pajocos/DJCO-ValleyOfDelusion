using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public CharacterMovement movement;

    private int floorContacts = 0;
    private RaycastHit hit;
    private float dist = 1f;
    private Vector3 dir= new Vector3(0, -1, 0);
    private Transform transform;

    public bool canMove;

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

        Debug.DrawRay(transform.position + Vector3.up, dir * dist, Color.red);
        if (Physics.Raycast(transform.position + Vector3.up, dir,out hit, dist)) {

            if (hit.collider.tag == "Floor") {
                if (!movement.grounded && movement.jumpSpeed < 0 ) {
                    movement.grounded = true;
                    Debug.Log("grounded");
                    movement.jumpSpeed = 0;

                }
            }
            
        } else {
            movement.grounded = false;
        }

    }
        
}
