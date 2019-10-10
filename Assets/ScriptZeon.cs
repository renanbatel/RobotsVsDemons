using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptZeon : MonoBehaviour
{
    public const int STATE_STANDING = 0;
    public const int STATE_RUNNING = 1;
    public const int STATE_JUMPING = 2;
    public const int STATE_FALLING = 3;
    
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private AudioSource AudioSource;
    private ScriptGameController ScriptGameController;
    private bool IsGoingRight;
    private bool IsOnTheGround;
    private bool HasJumped;

    public GameObject Feet;
    public LayerMask LayerMask;
    public float Velocity = 5;
    public int JumpForce = 850;

    private int GetState()
    {
        return this.Animator.GetInteger("STATE");
    }

    private void SetState(int state) {
        this.Animator.SetInteger("STATE", state);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.SetupValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.ScriptGameController.IsPaused()) {
            this.HandleMovement();
        }
    }

    void SetupValues()
    {
        this.Rigidbody2D = GetComponent<Rigidbody2D>();
        this.Animator = GetComponent<Animator>();
        this.AudioSource = GetComponent<AudioSource>();
        this.ScriptGameController = (GameObject.Find("GameController")).GetComponent<ScriptGameController>();
        this.IsGoingRight = true;
    }

    void HandleMovement()
    {
        Collider2D collider2D = null;
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (this.GetState() != STATE_JUMPING) {
            if (horizontalAxis == 0) {
                this.SetState(STATE_STANDING);
            } else {
                this.SetState(STATE_RUNNING);
            }
        }

        if ((horizontalAxis < 0 && this.IsGoingRight) || (horizontalAxis > 0 && !this.IsGoingRight)) {
            this.transform.Rotate(new Vector2(0, 180));
            this.IsGoingRight = !this.IsGoingRight;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.IsOnTheGround) {
            this.Rigidbody2D.AddForce(new Vector2(0, this.JumpForce));
            
            if (!this.AudioSource.isPlaying) {
                this.AudioSource.Play();
            }

            this.HasJumped = true;            
        }

        if (collider2D = Physics2D.OverlapCircle(this.Feet.transform.position, 0.2f, this.LayerMask)) {
            this.transform.parent = collider2D.transform;
            this.IsOnTheGround = true;

            if (this.GetState() == STATE_JUMPING || this.GetState() == STATE_FALLING) {
                this.HasJumped = false;

                this.SetState(STATE_STANDING);
            }
        } else {
            this.transform.parent = null;
            this.IsOnTheGround = false;
            
            if (this.GetState() != STATE_JUMPING && this.GetState() != STATE_FALLING) {
                if (this.HasJumped) {
                    this.SetState(STATE_JUMPING);
                } else {
                    this.SetState(STATE_FALLING);
                }
            }
        }

        this.Rigidbody2D.velocity = new Vector2(
            horizontalAxis * this.Velocity,
            this.Rigidbody2D.velocity.y
        );
    }

    void HandleFalling()
    {
        this.SetState(STATE_FALLING);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
