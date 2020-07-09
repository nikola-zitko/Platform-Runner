using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public bool facingRight = true; 
    public float moveSpeed = 3.0f;
    public float jumpForce = 200.0f;
    float dirX;
    Rigidbody2D rb;

    bool doubleJumpAllowed = false;
    bool onTheGround = true;


    void Start(){
        rb = GetComponent<Rigidbody2D> ();
        
        
    }


    void OnCollisionEnter2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Ground")
            {
                onTheGround = true;
                animator.SetLayerWeight(1,0);
                doubleJumpAllowed = true;
            }
        }

	void OnCollisionExit2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Ground")
            {
                onTheGround = false;
            }
        }

    void Update (){
        

        if(onTheGround && Input.GetButtonDown("Jump")) {
            Jump();
            animator.SetLayerWeight(1,1);
            
        }
        else if(doubleJumpAllowed && Input.GetButtonDown("Jump")){
            Jump();
            animator.SetLayerWeight(1,1);
            doubleJumpAllowed = false;
        }

        dirX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            

            
            float h = Input.GetAxis("Horizontal");
            if(h > 0 && !facingRight)
                Flip();
            else if(h < 0 && facingRight)
                Flip();

            
           rb.velocity = new Vector2 (dirX, rb.velocity.y);
         }

    void Flip ()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    
    void Jump(){
        
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce (Vector2.up * jumpForce);
        if(facingRight){
            rb.AddForce (Vector2.right * 200.0f);
        }
        if(!facingRight){
            rb.AddForce (Vector2.left * 200.0f);
        }
    }
    
     

}
