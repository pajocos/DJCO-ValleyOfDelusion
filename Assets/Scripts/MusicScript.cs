using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour
{


    public Collider[] triggers;
    public Collider[] EnvironmentTriggers;
    public AudioClip[] audios;
    public AudioClip[] environments;
    public AudioSource backgroundMusic;
    public AudioSource animationSound;
    public AudioSource environmentSounds;
    public AudioClip[] grass_steps;
    public AudioClip[] grass_run;
    public AudioClip[] stone_steps;
    public AudioClip[] stone_run;
    public AudioClip defeat;
    public AudioClip cristal_capture;


    private AudioClip currentStep;
    private int savedIndex = 0;
    private int envIndex = 0;
    public bool background;
    // Use this for initialization
    void Awake()
    {
        //if (background) {
        //    Invoke("UpdateMusic", audios[savedIndex].length);
        //}        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMusic();
        if (environments.Length > 0)
            UpdateEnvironment();
    }

    public void changeMusicAndEnvironment(Collider other)
    {
        if (other.tag == "MusicDetector" && background)
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                if (triggers[i] == other)
                {
                    savedIndex = i;
                }
            }

            for (int i = 0; i < EnvironmentTriggers.Length; i++)
            {
                if (EnvironmentTriggers[i] == other)
                {
                    envIndex = i;
                    UpdateEnvironment();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        changeMusicAndEnvironment(other);
    }

    void UpdateMusic()
    {
        if (background && !backgroundMusic.isPlaying)
        {
            backgroundMusic.clip = audios[savedIndex];
            backgroundMusic.Play();
            Debug.Log(backgroundMusic.clip.name);
            //Invoke("UpdateMusic", audios[savedIndex].length);
        }
    }

    void UpdateEnvironment()
    {
        if (environmentSounds.clip != environments[envIndex] || !environmentSounds.isPlaying)
        {
            environmentSounds.clip = environments[envIndex];
            print(environmentSounds.clip.name);
            environmentSounds.Play();
        }
        //Invoke("UpdateMusic", audios[savedIndex].length);

    }

    public void StepSound(string ident)
    {

        if (animationSound.clip == cristal_capture && animationSound.isPlaying)
            return;
        int vl = (int)(Random.value * stone_steps.Length);
        int vlImp = 1;
        if (vl % 2 == 0)
        {
            vlImp = vl + 1;
        }
        else
        {
            vlImp = vl;

            vl = vl - 1;
        }
        //Debug.Log("identifier : " + ident);

        if (ident.Equals("LeftFoot"))
        {
            currentStep = stone_steps[vl];
        }
        else if (ident.Equals("RightFoot"))
        {
            currentStep = stone_steps[vlImp];
        }
        else if (ident.Equals("LeftFootRun"))
        { //TODO isto ta merda
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                return;
            }
            currentStep = stone_run[vl];
        }
        else if (ident.Equals("RightFootRun"))
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                return;
            }

            currentStep = stone_run[vlImp];

        }
        else
        {
            Debug.Log("Step error : string identifier from animation event not found");

        }
        animationSound.Stop();
        animationSound.clip = currentStep;
        //Debug.Log(currentStep.name);
        animationSound.Play();
    }

    public void DefeatSound()
    {
        animationSound.Stop();
        backgroundMusic.Stop();
        backgroundMusic.clip = defeat;
        backgroundMusic.Play();
    }

    public void GemSound()
    {
        animationSound.Stop();
        animationSound.clip = cristal_capture;
        animationSound.Play();
    }
}
