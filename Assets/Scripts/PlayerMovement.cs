using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRigidBody;
    public float speed = 1f;
    public float jumpSpeed = 300;
    bool isGrounded = true;
    public Animator playerAnimator;
    public SpriteRenderer spriteRenderer;

    void Start() {
        
    }

    void Update() {
        playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRigidBody.velocity.y);

        bool isWalking = IsWalking();
        playerAnimator.SetBool("isWalking", isWalking);
        if(isWalking) {
            spriteRenderer.flipX = IsGoingToLeft();
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            playerRigidBody.AddForce(Vector2.up * jumpSpeed);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump");
        } 
    }

    private bool IsWalking() {
        return Input.GetAxis("Horizontal") != 0;
    }

    private bool IsGoingToLeft() {
        return Input.GetAxis("Horizontal") < 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("ground")) {
            isGrounded = true;
        }
    }
}
