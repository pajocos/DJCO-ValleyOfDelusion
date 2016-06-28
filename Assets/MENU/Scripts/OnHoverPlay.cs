using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverPlay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource Audio;
    public Text text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize = 18;
        text.color = Color.cyan;
        Audio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize = 14;
        text.color = Color.white;
    }
}