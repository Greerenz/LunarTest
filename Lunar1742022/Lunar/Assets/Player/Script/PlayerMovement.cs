using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public static bool move = true;
    public Animator animator;
    Vector2 movement;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (move)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement != Vector2.zero)
            {
                animator.SetBool("Move", true);
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
            else
            {
                animator.SetBool("Move", false);
            }
            animator.SetFloat("Movement", movement.sqrMagnitude);
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetFloat("Movement", 0);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
