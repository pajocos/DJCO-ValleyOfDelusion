using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


    public Collider[] triggers;
    public AudioClip[] audios;
    public AudioSource backgroundMusic;
    public AudioSource animationSound;
    public AudioClip[] grass_steps;
    public AudioClip[] grass_run;
    public AudioClip[] stone_steps;
    public AudioClip[] stone_run;
    private AudioClip currentStep;
    private int savedIndex = 0;

    // Use this for initialization
    void Start() {
        Invoke("UpdateMusic", audios[savedIndex].length);

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {

        for (int i = 0; i < triggers.Length; i++) {
            if (triggers[i] == other) {
                savedIndex = i;
            }
        }


    }

    void UpdateMusic() {

        backgroundMusic.clip = audios[savedIndex];
        backgroundMusic.Play();
        Invoke("UpdateMusic", audios[savedIndex].length);

    }

    public void StepSound(string ident) {

        int vl = (int)(Random.value * 20);
        int vlImp = 1;
        if (vl % 2 == 0) {
            vlImp = vl + 1;
        } else {
            vlImp = vl;

            vl = vl - 1;
        }
        //Debug.Log("identifier : " + ident);

        if (ident.Equals("LeftFoot")) {
            currentStep = stone_steps[vl];
        } else if (ident.Equals("RightFoot")) {
            currentStep = stone_steps[vlImp];
        } else if (ident.Equals("LeftFootRun")) { //TODO isto ta merda
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) {
                return;
            }
            currentStep = stone_run[vl];
        } else if (ident.Equals("RightFootRun")) {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) {
                return;
            }

            currentStep = stone_run[vlImp];

        } else {
            Debug.Log("Step error : string identifier from animation event not found");

        }
        animationSound.Stop();
        animationSound.clip = currentStep;
        //Debug.Log(currentStep.name);
        animationSound.Play();
    }
}
