using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int health = 3;
    public Image[] hearts;
    public Animator animator;
    public AudioSource hitSound;
    private bool hasCooldown = false;
    private Rigidbody2D playerRigidbody;

    private void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") && GetComponent<PlayerMovement>().isGrounded)
        {
            SubstractHealth();
        }
    }

    void SubstractHealth()
    {
        if (!hasCooldown)
        {
            if (health > 0)
            {
                health --;
                hasCooldown = true;
                animator.SetTrigger("Hit");
                playerRigidbody.AddForce(Vector2.right * 20);
                hitSound.Play();
                StartCoroutine(Cooldown());
                
            }
            else
            {
                Router.ShowScene("LoseScene");
            }
        }

        EmptyHearts();
    }

    void EmptyHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health - 1 < i)
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        hasCooldown = false;

        StopCoroutine(Cooldown());
    }
}
