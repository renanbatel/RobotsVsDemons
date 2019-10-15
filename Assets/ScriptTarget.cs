using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTarget : MonoBehaviour
{
    private ScriptGameController ScriptGameController;

    public GameObject GameController;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
    }

    void SetupValues()
    {
        this.ScriptGameController = this.GameController.GetComponent<ScriptGameController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            this.ScriptGameController.FinishGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
