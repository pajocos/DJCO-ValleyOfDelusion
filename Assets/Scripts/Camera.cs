using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    public float damping;
    Vector3 offset;

    private bool canMove;

    void Start()
    {
        offset = player.transform.position - transform.position;
        canMove = true;
    }

    void Update()
    {
        player.GetComponent<PlayerBehaviour>().canMove = canMove;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            canMove = false;
        else if (Input.GetMouseButton(0))
        {
            transform.RotateAround(player.transform.position, player.transform.up,
                Input.GetAxis("Mouse X") * 90 * Time.deltaTime);
            transform.RotateAround(player.transform.position, player.transform.right,
                Input.GetAxis("Mouse Y") * 90 * Time.deltaTime);
        }
        else if(Input.GetMouseButtonUp(0))
            canMove = true;
        else
        {
            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = player.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.position = player.transform.position - (rotation * offset);
        }
        transform.LookAt(player.transform);
    }
}
