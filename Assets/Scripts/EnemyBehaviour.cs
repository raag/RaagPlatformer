using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float delay = 0.5f;
    public float speed = 1f;
    private Rigidbody2D enemyRigidBody;
    private float timeBeforeChange;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        timeBeforeChange = 0f;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = enemyRigidBody.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        enemyRigidBody.velocity = Vector2.right * speed;
        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            spriteRenderer.flipX = IsGoingToRight();
            timeBeforeChange = Time.time + delay;
        } 
    }

    private bool IsGoingToRight() 
    {
        return speed < 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y + 0.3f)
        {
            animator.SetTrigger("KillEnemy");
        }
    }

    public void KillEnemy()
    {
        gameObject.SetActive(false);
    }
}