using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LabyrinthTeleport : MonoBehaviour
{

    public Vector3 Destination;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            PlayerBehaviour.StartPosition = Destination;
             SceneManager.LoadScene(1);

        }

    }
}
