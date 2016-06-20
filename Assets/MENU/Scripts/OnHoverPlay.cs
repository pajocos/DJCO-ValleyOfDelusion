using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverPlay : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource Audio;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        Audio.Play();
    }
}
