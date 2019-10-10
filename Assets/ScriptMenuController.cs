using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptMenuController : MonoBehaviour
{
    private GameObject ButtonStartText;
    private Text ButtonStartTextText;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
        this.PrepareScenario();
    }

    void SetupValues()
    {
        this.ButtonStartText = GameObject.Find("/Canvas/ButtonStart/Text");
        this.ButtonStartTextText = this.ButtonStartText.GetComponent<Text>();
    }

    void PrepareScenario()
    {
        if (SceneManager.sceneCount > 1) {
            this.ButtonStartTextText.text = "RESUME";
        }
    }

    public void loadGame()
    {
        if (SceneManager.sceneCount > 1) {
            Time.timeScale = 1;
            
            SceneManager.UnloadSceneAsync(0);
        } else {
            SceneManager.LoadScene(1);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
