using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    //private Renderer renderer;

    public AudioClip[] clips;
    public AudioSource source;

    public Renderer body;
    public Renderer masq;

    private Material[] materials;
    private Color[] original_colors;

    public float FadeTime = 1f;
    private float tempTime = 0;

    void Start()
    {
        materials = new Material[masq.materials.Length + body.materials.Length];

        for(int i = 0; i < masq.materials.Length + body.materials.Length; i++)
        {
            if(i < masq.materials.Length)
                materials[i] = masq.materials[i];
            else
                materials[i] = body.materials[i-masq.materials.Length];
        }


        original_colors = new Color[materials.Length];

        for(int i = 0; i < materials.Length;i++)
        {
            original_colors[i] = materials[i].GetColor("_Color");
            original_colors[i].a = 1;
        }

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

            for (int i = 0; i < materials.Length; i++)
            {
                
                Color temp = original_colors[i];
                temp.a = 0;

                
                materials[i].SetFloat("_Mode", 2);
                materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                materials[i].SetInt("_ZWrite", 0);
                materials[i].DisableKeyword("_ALPHATEST_ON");
                materials[i].EnableKeyword("_ALPHABLEND_ON");
                materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");

                materials[i].SetColor("_Color", Color.Lerp(original_colors[i], temp, tempTime / FadeTime));
                /*if (materials[i].color.a == 0)
                {
                    gameObject.SetActive(false);
                    enabled = false;
                }*/


            }

            tempTime += Time.deltaTime;

        }
    }
}