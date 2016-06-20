using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject pauseMenuTint;
    private ButtonBehavior behaviour;
    private bool isPaused;

    void Awake()
    {
        behaviour = GetComponent<ButtonBehavior>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused && !behaviour.inMainMenu)
        {
            Pause();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused && !behaviour.inMainMenu)
        {
            ResumeGame();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseMenuTint.SetActive(true);
    }


    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseMenuTint.SetActive(false);
    }

    public void SaveGame()
    {
    }

    public void ResumeToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}