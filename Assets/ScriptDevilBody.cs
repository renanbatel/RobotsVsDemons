using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDevilBody : MonoBehaviour
{
    private ScriptDevil ScriptDevil;
    private ScriptGameController ScriptGameController;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupVales();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!this.ScriptDevil.HasDied()) {
            if (collider.gameObject.layer != 0) {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                    this.ScriptDevil.SwapDirection();
                }
            } else {
                if (collider.gameObject.tag == "Player") {
                    this.ScriptGameController.GameOver();
                }
            }
        }
    }

    void SetupVales()
    {
        GameObject gameController = GameObject.Find("GameController");
        this.ScriptGameController = gameController.GetComponent<ScriptGameController>();
        this.ScriptDevil = this.GetComponentInParent<ScriptDevil>();
    }
}
