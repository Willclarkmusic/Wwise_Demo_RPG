using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Transform pfDoubleJumpEffect;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float walkSpeed = 10f;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private PlayerLife life;
    private int airJumpCount;
    public int airJumpCountMax = 1;
    public int bounce = 5;
    public int damageAmount = 1;
    public GameObject chicken;
    public Player_Audio playerAudio;
    private enum MovementState {idle, running, jumping, falling, doubleJump}

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        life = GetComponent<PlayerLife>();
        playerAudio = GetComponent<Player_Audio>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);

        if (isGrounded())
        {            
            airJumpCount = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            //Normal Jump
            {
                playerAudio.playJumpSound();
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            //Double Jump
            {
                if (airJumpCount < airJumpCountMax)
                {
                    playerAudio.playDoubleJumpSound();
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                    airJumpCount++;
                    Instantiate(pfDoubleJumpEffect, transform.position, Quaternion.identity);
                }
            }
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y != 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
        UpdateAnimationState();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Fruit"))
        {
            playerAudio.playCollectFruitSound();
            Destroy(trig.gameObject);
            airJumpCountMax++;
        }
        else if (trig.gameObject.CompareTag("Chicken"))
        {
            playerAudio.playBounceSound();
            rb.velocity = new Vector2(rb.velocity.x, bounce);
            chicken.GetComponent<ChickenPatrol>().TakeDamage(damageAmount);
        }
        else if (trig.gameObject.CompareTag("WinState"))
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            playerAudio.playDeathSound();
            life.Die();
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            playerAudio.playLandSound();
        }

    }

    private void UpdateAnimationState()
    {
        MovementState state;
        //runstate
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        //jump state
        if (rb.velocity.y > .1f)
        {
            if (airJumpCount == 0)
            {
                state = MovementState.jumping;
            }
            else
            {
                state = MovementState.doubleJump;

            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
