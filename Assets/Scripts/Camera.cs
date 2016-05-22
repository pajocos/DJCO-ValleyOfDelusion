using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerBehaviour player;
    public float damping;
    Vector3 offset;

    private bool canMove;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5,
            player.transform.position.z - 10);
        offset = player.transform.position - transform.position;
        player.canMove = true;
    }

    void LateUpdate()
    {
        var velocity = player.movement.internalVelocity;

        if (Input.GetMouseButtonDown(0) && player.movement.internalVelocity == Vector3.zero)
            player.canMove = false;
        else if (Input.GetMouseButton(0) && player.movement.internalVelocity == Vector3.zero)
        {
            transform.RotateAround(player.transform.position, player.transform.up,
                Input.GetAxis("Mouse X")*90*Time.deltaTime);
            transform.RotateAround(player.transform.position, player.transform.right,
                Input.GetAxis("Mouse Y")*90*Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0) && player.movement.internalVelocity == Vector3.zero)
            player.canMove = true;
        else
        {
            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = player.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime*damping);

            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.position = player.transform.position - (rotation*offset);
        }
        transform.LookAt(player.transform);
    }
}