using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDevil : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    private AudioSource AudioSource;
    private bool Died = false;
    private string Direction = "right";

    public float Speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
        this.GoRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Direction == "right") {
            this.transform.position += new Vector3(this.Speed * Time.deltaTime, 0, 0);
        } else if (this.Direction == "left") {
            this.transform.position -= new Vector3(this.Speed * Time.deltaTime, 0, 0);
        }
    }

    void SetupValues()
    {
        this.Rigidbody2D = GetComponent<Rigidbody2D>();
        this.Animator = GetComponent<Animator>();
        this.SpriteRenderer = GetComponent<SpriteRenderer>();
        this.AudioSource = GetComponent<AudioSource>();
    }

    public bool HasDied()
    {
        return this.Died;
    }

    public void SwapDirection()
    {
        if (this.Direction == "right") {
            this.GoLeft();
        } else if (this.Direction == "left") {
            this.GoRight();
        }
    }

    public void GoRight()
    {
        if (this.Direction != "right") {
            this.transform.Rotate(new Vector2(0, 180));
        }

        this.Direction = "right";
    }

    public void GoLeft()
    {
        if (this.Direction != "left") {
            this.transform.Rotate(new Vector2(0, 180));
        }

        this.Direction = "left";
    }

    public void Die()
    {
        this.Died = true;
        this.Direction = "none";

        if (!this.AudioSource.isPlaying) {
            this.AudioSource.Play();
        }
        this.Animator.SetBool("DIED", true);
    }

    public void HandleDyingEnd()
    {
        Destroy(this.gameObject);
    }
}
