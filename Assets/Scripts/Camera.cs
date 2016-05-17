using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    private float disMax, disCurrent;
    private Quaternion initialRotation;
    private Vector3 initialPos;

    void Start()
    {
        disMax = 10;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialRotation = transform.rotation;
            initialPos = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            transform.RotateAround(player.transform.position, player.transform.up,
                Input.GetAxis("Mouse X") * 45 * Time.deltaTime);
            transform.RotateAround(player.transform.position, player.transform.right,
                Input.GetAxis("Mouse Y") * 45 * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.position = initialPos;
            transform.rotation = initialRotation;
            //transform.position = Vector3.Lerp(transform.position,initialPos, Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation,initialRotation, Time.deltaTime);
        }
        disCurrent = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform);
        if (disCurrent > disMax || disMax < -disMax)
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * disMax, Time.deltaTime);



        //PREVENIR ATRAVESSAR PAREDES e CHAO...
    //    RaycastHit colisionRay;

    //    if (Physics.Raycast(transform.position, transform.forward, out colisionRay))
    //    {
    //        if (colisionRay.transform != player.transform)
    //        {
    //            transform.position = colisionRay.point + transform.forward * 2;
    //        }

    //    }
    }
}
