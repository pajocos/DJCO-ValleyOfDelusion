using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverPlay : MonoBehaviour
{

    public AudioClip clip;
    private AudioSource audio;

	void Start ()
	{
	    audio = new AudioSource();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        audio.PlayOneShot(clip);
    }
}
