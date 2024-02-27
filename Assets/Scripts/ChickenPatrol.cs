using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public Animator animator;
    public GameObject player;
    public GameObject winBlocker;
    [SerializeField] private Transform pfChickenDie;
    public float walkSpeed = 1.5f;
    public float runSpeed = 5f;
    public float idleTime = 5f;
    public float patrollTime = 10f;
    public float stopAttacking = 20f;
    public float attackRange = 10f;
    public int chickenHealth = 3;

    private SpriteRenderer spriteRenderer;
    private Transform playerPos;
    private float timer;
    private Rigidbody2D rb;
    private Transform currentPos;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPos = player.GetComponent<Transform>();
        timer = idleTime;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPos = PointB.transform;
        animator.SetBool("isPatrolling", false);
        animator.SetBool("isChasing", false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, playerPos.position) < attackRange)
        {
            animator.SetBool("isChasing", true);
        }

        if (rb.velocity.x < 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x > 0f)
        {
            spriteRenderer.flipX = true;
        }


        if (animator.GetBool("isPatrolling") == true && animator.GetBool("isChasing") == false)
        {
            Patrol();

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
            {
                animator.SetBool("isPatrolling", false);
            }
        }
        else if (animator.GetBool("isPatrolling") == false && animator.GetBool("isChasing") == false)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                animator.SetBool("isPatrolling", true);
                timer = idleTime;
            }
        }
        else if (animator.GetBool("isChasing") == true)
        {
            Chase();
        }

    }

    public void TakeDamage(int damageAmnt)
    {
        chickenHealth -= damageAmnt;
        if (chickenHealth <= 0)
        {
            Die();
        }
        else if (chickenHealth > 0)
        {
            animator.SetTrigger("isHit");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(pfChickenDie, transform.position, Quaternion.identity);
        animator.SetTrigger("Die");
        Destroy(winBlocker);
    }

    private void Patrol()
    {
        if (currentPos == PointB.transform)
        {
            rb.velocity = new Vector2(walkSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-walkSpeed, 0);
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == PointB.transform)
        {
            currentPos = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == PointA.transform)
        {
            currentPos = PointB.transform;
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position , playerPos.position, runSpeed * Time.deltaTime);
    }



}
