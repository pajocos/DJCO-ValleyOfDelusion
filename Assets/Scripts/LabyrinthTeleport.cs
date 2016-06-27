using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LabyrinthTeleport : MonoBehaviour
{

    public int Scene = 1;
    public Vector3 Destination;

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Stop();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            sound.Play();

            PlayerBehaviour.StartPosition = Destination;
            Invoke("loadScene", 2.6f);
        }

    }

    private void loadScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
