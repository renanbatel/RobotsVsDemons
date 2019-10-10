using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMainCamera : MonoBehaviour
{
    public GameObject Zeon;
    public float XOffset = 2;
    public float YOffset = 1;

    // Update is called once per frame
    void Update()
    {
        if (this.Zeon) {
            float positionX = this.Zeon.transform.position.x + this.XOffset;
            float positionY = this.Zeon.transform.position.y + this.YOffset;

            if (positionX < 0) {
                positionX = 0;
            }
            if (positionY < 0 && positionY > -5) {
                positionY = 0;
            }
            
            this.transform.position = new Vector3(positionX, positionY, -10);
        }
    }
}
