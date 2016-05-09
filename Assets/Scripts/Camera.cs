using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
    private float disMax, disCurrent;

	void Start () {
        disMax = 10;
	}
	
	void Update () {
        transform.RotateAround(player.transform.position, player.transform.up, Input.GetAxis("Mouse X") * 90 * Time.deltaTime);
        transform.RotateAround(player.transform.position, player.transform.right, Input.GetAxis("Mouse Y") * 90 * Time.deltaTime);

        disCurrent = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform);
        if (disCurrent > disMax || disMax < -disMax)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * disMax, Time.deltaTime);
        }

        //struct Quaternion = Quaternion.FromToRotation(player.forward, transform.forward) * transform.rotation;

        //transform.rotation.eulerAngles.y = Quaternion.Lerp(transform.rotation, RotacaoRefCam, Time.deltaTime).eulerAngles.y;
    }
}
