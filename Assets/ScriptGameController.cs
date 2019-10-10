using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameController : MonoBehaviour
{
    private AudioSource AudioSource;
    private ScriptZeon ScriptZeon;

    public GameObject Zeon;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.PauseGame();
        }
    }

    void SetupValues()
    {
        this.ScriptZeon = this.Zeon.GetComponent<ScriptZeon>();
        this.AudioSource = GetComponent<AudioSource>();
    }

    void PauseGame()
    {
        if (SceneManager.sceneCount == 1) {
            Time.timeScale = 0;

            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        } else {
            Time.timeScale = 1;

            SceneManager.UnloadSceneAsync(0);
        }
    }

    public void GameOver()
    {
        if (!this.AudioSource.isPlaying) {
            this.AudioSource.Play();
        }
        this.ScriptZeon.Die();
    }

    public bool IsPaused()
    {
        return Time.timeScale == 0;
    }
}
