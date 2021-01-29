using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float gravityScale = 5f;
    [SerializeField]
    public float movementSpeed = 6f;
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask iceLayers;
    public LayerMask sandLayers;
    public Transform feet;
    public LayerMask groundLayers;
        [SerializeField]
    private float jumpForce = 5f;
    private bool pressedJump = false;
    private bool releasedJump = false;
    private bool startTimer = false;
    [SerializeField]
    private float jumpTimer = 0.5f;
    private float jtimer;
    float mx;
    [HideInInspector] 
    public bool isFacingRight = true;

    private void Awake() { 
        rb = GetComponent<Rigidbody2D>();
        
        jtimer = jumpTimer;
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
            jtimer -= Time.deltaTime;
            if(jtimer <= 0) {
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

    public bool IsOnIce() {
        Collider2D iceCheck = (Physics2D.OverlapCircle(feet.position, 0.25f, iceLayers));
        if (iceCheck != null) {
            movementSpeed = 15f;
            return true;
        }
            movementSpeed = 7f;
            return false;
    }
        public bool IsOnSand() {
        Collider2D sandCheck = (Physics2D.OverlapCircle(feet.position, 0.25f, sandLayers));
        if (sandCheck != null) {
            movementSpeed = 3f;
            return true;
        }
            movementSpeed = 7f;
            return false;
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
        jtimer = jumpTimer;
        startTimer = false;
    }
   private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("EndZone")) {
        MainScript.instance.EndGame();
        }
   } 
}
