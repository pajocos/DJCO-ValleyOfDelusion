using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    //private Renderer renderer;

    public AudioClip[] clips;
    public AudioSource source;

    public Renderer body;
    public Renderer masq;

    public Renderer bodyFade;
    public Renderer masqFade;


    private Color original_color_masq;
    private Color original_color_body;

    public float FadeTime = 1f;
    private float tempTime = 0;

    void Start()
    {
        original_color_masq = masqFade.material.color;
        original_color_body = bodyFade.material.color;

        source.clip = clips[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.color =
        //    new Color(1.0f, 1.0f, 0.5f, 1.0f);
        

        if (PlayerBehaviour.gems == 0)
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 2, 0), Time.deltaTime*45f);
            if(!source.isPlaying)
            {
                int r = Random.Range(0, clips.Length - 1);
                source.clip = clips[r];
                source.Play();
            }

        }
        else if (PlayerBehaviour.gems == 1)
        {

            if (body.material != bodyFade)
            {
                body.material = bodyFade.material;
            }

            if (masq.material != masqFade)
            {
                masq.material = masqFade.material;
            }

            Color temp = original_color_body;
            temp.a = 0;

            body.material.SetColor("_Color", Color.Lerp(original_color_body, temp, tempTime / FadeTime));

            temp = original_color_masq;
            temp.a = 0;

            masq.material.SetColor("_Color", Color.Lerp(original_color_masq, temp, tempTime / FadeTime));

            if(masq.material.color.a == 0 || body.material.color.a == 0)
            {
                gameObject.SetActive(false);
                enabled = false;
            }

            tempTime += Time.deltaTime;

        }
    }
}