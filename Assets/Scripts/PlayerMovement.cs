using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private Vector2 moveInput; //for walk with addforce   
            
    //walk left-right
    private float move;
    [SerializeField] private float speed;
    
    //Jump
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isJumping;
    
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        
        //walk
        /*move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);*/
        
        //jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2( rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!"); //For debugging
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
