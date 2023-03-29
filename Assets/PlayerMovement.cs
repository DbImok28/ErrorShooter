using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    private CapsuleCollider collider;
    public LayerMask layerMask;

    public float movementSpeed = 0.05f;
    private bool isJumping;
    private bool crouch;

    float vertical;
    float horizontal;

    bool jumpPressed;
    bool shootPressed;
    bool crouchPressed;
    bool stabPressed;


    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    public void HandleInput()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        if (Input.GetKey(KeyCode.F))
        {
            shootPressed = true;
        }
        else
        {
            shootPressed = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            crouchPressed = true;
        }
        else
        {
            crouchPressed = false;
        }



    }

    public void Jump()
    {

        if (jumpPressed)
        {
            if (isGrounded())
            {
                rigidbody.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }

            animator.SetBool("jump", true);
        }
        if (isGrounded())
        {
            animator.SetBool("jump", false);
        }
    }

    public void Shoot()
    {
        if (shootPressed)
        {
            animator.SetBool("shoot", true);
            Debug.Log("shooting");
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }

    public void Move()
    {
        
        if (crouchPressed)
        {
            animator.SetBool("crouch", true);
            Debug.Log("crouching");
        }
        else
        {
            animator.SetBool("crouch", false);
        }
        
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement.Normalize();
        transform.position += movement * movementSpeed;

        animator.SetFloat("vertical", vertical);
        animator.SetFloat("horizontal", horizontal);
        
    }



    public void Stab()
    {

    }

    public void Animate()
    {
        Move();
        Jump();
        Shoot();
        Stab();

    }

    private bool isGrounded()
    {
        if (Physics.CheckSphere(transform.position + Vector3.down, 0.2f, layerMask))
        {
            return true;
        }
        return false;
    }

    void FixedUpdate()
    {
        HandleInput();
        Animate();
    }
}
