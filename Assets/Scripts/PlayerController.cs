using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float groundCheckRadius;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    public Transform firePoint;
    public GameObject fireBall;

    private Rigidbody2D rb2d;
    private Animator playerAnim;
    private float moveVelocity;
    private bool grounded;
    private bool doubleJump;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockBack;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockFromRight;

    public bool onLadder;
    public float climbSpeed;

    private float climbVelocity;
    private float gravityStore;
    
    // Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        gravityStore = rb2d.gravityScale;
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update() {

        if (grounded)
            doubleJump = false;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        // Make the player jump
        if (Input.GetButton("Jump") && grounded)
            Jump();

        // Make the player double jump
        if (Input.GetButtonDown("Jump") && !doubleJump && !grounded) {
            Jump();
            doubleJump = true;
        }

        Move(Input.GetAxisRaw("Horizontal"));
#endif

        if (knockBackCount <= 0) {
            rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
        }

        else {
            if (knockFromRight) {
                rb2d.velocity = new Vector2(-knockBack, knockBack);
            }
            else {
                rb2d.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }


        playerAnim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        playerAnim.SetBool("Grounded", grounded);

        // Decides which way the player is facing
        // Positive x is right, negative x is left
        if (rb2d.velocity.x > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (rb2d.velocity.x < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        // Shoot a fireball
        if (Input.GetButtonDown("Fire1")) {
            Fire();
            shotDelayCounter = shotDelay;
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Fire();
            }
        }

        if (playerAnim.GetBool("Attack")) {
            ResetSword();
        }

        if (Input.GetButtonDown("Fire2")) {
            Sword();
        }
#endif

        if (onLadder) {
            rb2d.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);
            playerAnim.SetBool("Climbing", true);
        }

        if (!onLadder) {
            rb2d.gravityScale = gravityStore;
            playerAnim.SetBool("Climbing", false);
        }
    }

    public void Move(float moveInput) {
        moveVelocity = moveSpeed * moveInput;
    }

    public void Fire() {
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }

    public void Sword() {
        playerAnim.SetBool("Attack", true);
    }

    public void ResetSword() {
        playerAnim.SetBool("Attack", false);
    }

    public void Jump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);

        // Make the player jump
        if (grounded)
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);

        // Make the player double jump
        if (!doubleJump && !grounded) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            doubleJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Moving Platform") {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        transform.parent = null;
    }
}
