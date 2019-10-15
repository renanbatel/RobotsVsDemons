using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptMenuController : MonoBehaviour
{
    private GameObject Zeon;
    private GameObject Target;
    private GameObject ButtonStartText;
    private Text ButtonStartTextText;
    private bool isPaused;
    private bool isGameOver;
    private bool isGameFinished;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
        this.PrepareScenario();
    }

    void SetupValues()
    {
        this.Zeon = GameObject.Find("Zeon");
        this.Target = GameObject.Find("Target");
        this.ButtonStartText = GameObject.Find("/Canvas/ButtonStart/Text");
        this.ButtonStartTextText = this.ButtonStartText.GetComponent<Text>();
        this.isPaused = this.Zeon && this.Target && SceneManager.sceneCount > 1;
        this.isGameOver = !this.Zeon && this.Target && SceneManager.sceneCount > 1;
        this.isGameFinished = this.Zeon && !this.Target && SceneManager.sceneCount > 1;
    }

    void PrepareScenario()
    {
        if (this.isPaused) {
            this.ButtonStartTextText.text = "RESUME";
        } else if (this.isGameOver || this.isGameFinished) {
            this.ButtonStartTextText.text = "RESTART";
        }
    }

    public void loadGame()
    {
        if (this.isPaused)
        {
            Time.timeScale = 1;

            SceneManager.UnloadSceneAsync(0);
        } else if (this.isGameOver || this.isGameFinished) {
            Time.timeScale = 1;

            SceneManager.UnloadScene(0);
            SceneManager.UnloadScene(1);
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(1);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
