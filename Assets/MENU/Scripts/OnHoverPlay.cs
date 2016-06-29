using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverPlay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource Audio;
    public Text text;
    public bool PauseMenu = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!PauseMenu)
        {
            text.fontSize = 18;
            text.color = Color.cyan;
        }
        Audio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!PauseMenu)
        {
            text.fontSize = 14;
            text.color = Color.white;
        }
    }
}