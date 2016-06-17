using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transparency : MonoBehaviour
{
    private Image ButtonBackground;
    public float transparency;

    // Use this for initialization
    void Start()
    {
        ButtonBackground = GetComponent<Image>();
        SetTransparency(transparency);
    }

    public void SetTransparency(float t)
    {
        //transparency is a value in the [0,1] range
        Color color = ButtonBackground.color;
        color.a = t;
        ButtonBackground.color = color;
    }
}