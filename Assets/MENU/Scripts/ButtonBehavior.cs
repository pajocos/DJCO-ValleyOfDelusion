using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    private float diff_buttons;
    private float diff_title;
    private float diff_history;
    private float diff_logo;

    public Transform title;
    public Transform logo;
    public Transform buttons;
    public Transform history;
    public Transform credits;

    private bool restorePos;
    private bool moveHistory;
    private bool moveCredits;
    private bool buttonsMoved;

    private Vector3 originalPosButtons;
    private Vector3 originalPosTitle;
    private Vector3 originalPosHistory;
    private Vector3 originalPosLogo;

    public AudioSource backgroundMusic;

    public bool inMainMenu;

    // Use this for initialization
    void Start()
    {
        diff_buttons = Screen.width*0.175f;
        diff_title = Screen.height*0.25f + title.position.y;
        diff_logo = Screen.height * 0.25f + logo.position.y;
        diff_history = Screen.width*0.66f;

        restorePos = false;
        moveCredits = false;
        moveHistory = false;
        buttonsMoved = false;

        originalPosButtons = buttons.transform.position;
        originalPosTitle = title.transform.position;
        originalPosLogo = logo.transform.position;
        originalPosHistory = history.transform.position;

        EventSystem.current.SetSelectedGameObject(null);
        
        inMainMenu = true;
    }

    // Update is called once per frame
    void MoveButtons()
    {
        buttons.position = Vector3.Lerp(buttons.position, new Vector3(diff_buttons, buttons.position.y, 0),
            Time.deltaTime*1.5f);
        title.position = Vector3.Lerp(title.position, new Vector3(title.position.x, diff_title, 0), Time.deltaTime*1.5f);
        logo.position = Vector3.Lerp(logo.position, new Vector3(logo.position.x, diff_logo, 0), Time.deltaTime * 1.5f);
    }

    void MoveHistory()
    {
        MoveButtons();

        history.position = Vector3.Lerp(history.position, new Vector3(diff_history, history.position.y, 0),
            Time.deltaTime*2f);

        if (!moveCredits)
            credits.position = Vector3.Lerp(credits.position, originalPosHistory, Time.deltaTime*2f);
    }

    void MoveCredits()
    {
        MoveButtons();

        credits.position = Vector3.Lerp(credits.position, new Vector3(diff_history, credits.position.y, 0),
            Time.deltaTime*2f);

        if (!moveHistory)
            history.position = Vector3.Lerp(history.position, originalPosHistory, Time.deltaTime*2f);
    }

    void MoveButtonsRestoreOriginal()
    {
        buttons.position = Vector3.Lerp(buttons.position, originalPosButtons, Time.deltaTime*1.5f);
        title.position = Vector3.Lerp(title.position, originalPosTitle, Time.deltaTime*1.5f);
        logo.position = Vector3.Lerp(logo.position, originalPosLogo, Time.deltaTime * 1.5f);
        history.position = Vector3.Lerp(history.position, originalPosHistory, Time.deltaTime*2f);
        credits.position = Vector3.Lerp(credits.position, originalPosHistory, Time.deltaTime*2f);
    }

    public void OpenHistory()
    {
        restorePos = false;
        moveCredits = false;
        moveHistory = true;
    }

    public void OpenCredits()
    {
        restorePos = false;
        moveHistory = false;
        moveCredits = true;
    }

    //IEnumerator LoadScene()
    //{
    //    var fadeTime = fading.BeginFade(1);
    //    yield return new WaitForSeconds(fadeTime);
    //    SceneManager.LoadScene(1);
    //}

    public void NewGame()
    {
        inMainMenu = false;

        GameObject menu = GameObject.Find("MainMenu");
        menu.SetActive(false);
        backgroundMusic.Stop();

        SceneManager.LoadScene(1);
    }

    public void Close()
    {
        restorePos = true;
        moveHistory = false;
        moveCredits = false;
    }

    void Update()
    {
        if (restorePos)
            MoveButtonsRestoreOriginal();
        else if (moveHistory)
            MoveHistory();
        else if (moveCredits)
            MoveCredits();
    }

    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}