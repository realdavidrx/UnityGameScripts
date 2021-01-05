using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float gravityScale = 5f;
    public float movementSpeed;
    private Rigidbody2D rb;
public Animator anim;

    public Transform feet;
    public LayerMask groundLayers;
        [SerializeField]
    private float jumpForce = 8f;
    private bool pressedJump = false;
    private bool releasedJump = false;
    private bool startTimer = false;
    [SerializeField]
    private float jumpTimer = 0.5f;
    private float timer;
    float mx;
    [HideInInspector] public bool isFacingRight = true;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
        timer = jumpTimer;
    }

    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            pressedJump = true;
        }

        if (Input.GetButtonUp("Jump")) {
            releasedJump = true;

        }

        if (startTimer) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                releasedJump= true;
            }
            
        }

        if (Mathf.Abs(mx) > 0.05f) {
            anim.SetBool("isRunning", true);
         } else {
            anim.SetBool("isRunning", false);
         }

    if (mx > 0f) {
        transform.localScale = new Vector3(6f, 6f, 6f);
        isFacingRight = true;
        } else if (mx < 0f) {
        transform.localScale = new Vector3 (-6f, 6f, 6f);
        isFacingRight = false;
        }
    anim.SetBool("isGrounded", IsGrounded());
     }
    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
        if (pressedJump) {
            StartJump();
        }

        if (releasedJump) {
            StopJump();
        }
    }

    private void StartJump() {
        rb.gravityScale = 0f;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.25f, groundLayers);
        if (groundCheck != null) {
            return true;
        }

        return false;
    }
    
    private void StopJump() {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }
}