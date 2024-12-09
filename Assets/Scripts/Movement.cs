using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 movement;
    public Animator animator;
    private float x, y;
    public Rigidbody rb;
    public float jumpHeight = 3;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;

    
    void Update(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movement = new Vector3(x, 0.0f, y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);

        isGrounded =Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(Input.GetKey("space") && isGrounded){
            animator.Play("jump");
            Invoke("Jump",0.5f);
        }
        
    } 
    public void Jump(){
        rb.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
    }
    
}
