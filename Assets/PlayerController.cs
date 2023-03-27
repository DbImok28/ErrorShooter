using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public LayerMask layerMask;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }

    public void CheckGround()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        anim.SetBool("jump", !isGrounded);
    }

    public void Jump()
    {
        Debug.Log(isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump keycode");
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
            
        }
    }

    public void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        movement.Normalize();

        transform.position += movement * 0.04f;

        anim.SetFloat("vertical", verticalAxis);
        anim.SetFloat("horizontal", horizontalAxis);
    }

    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Shooting");
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Jump();
        Move();
        Shoot();
    }
}
