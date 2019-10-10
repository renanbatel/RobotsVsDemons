using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenuCamera : MonoBehaviour
{
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
        this.PlayBackgroundMusic();
        this.PrepareScreen();
    }

    void SetupValues()
    {
        this.AudioSource = GetComponent<AudioSource>();
    }

    void PlayBackgroundMusic()
    {
        if (SceneManager.sceneCount == 1) {
            this.AudioSource.Play();
        }
    }

    void PrepareScreen()
    {
        if (SceneManager.sceneCount > 1) {
            GameObject menuGrid = GameObject.Find("MenuGrid");
            GameObject menuCamera = GameObject.Find("MenuCamera");

            if (menuGrid) {
                Destroy(menuGrid);
            }
            if (menuCamera) {
                Destroy(menuCamera);
            }
        }
    }
}
