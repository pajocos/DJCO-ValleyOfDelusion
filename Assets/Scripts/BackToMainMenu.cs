using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
