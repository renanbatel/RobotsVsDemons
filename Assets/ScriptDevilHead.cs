using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDevilHead : MonoBehaviour
{
    private ScriptDevil ScriptDevil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") {
            this.ScriptDevil.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.ScriptDevil = this.GetComponentInParent<ScriptDevil>();
    }
}
