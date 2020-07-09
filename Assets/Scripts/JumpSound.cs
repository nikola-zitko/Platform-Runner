using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour{



    bool onTheGround = true;
    bool doubleJumpAllowed = false;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Ground")
            {
                onTheGround = true;
                doubleJumpAllowed = true;
            }
        }

	void OnCollisionExit2D(Collision2D collision){
        
            if (collision.gameObject.tag == "Ground")
            {
                onTheGround = false;
            }
        }

    // Update is called once per frame
    void Update (){
        

        if(onTheGround && Input.GetButtonDown("Jump")) {
            GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("jump1");
            GetComponent<AudioSource> ().Play ();
        }
        else if(doubleJumpAllowed && Input.GetButtonDown("Jump")){
            
            GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("jump2");
            GetComponent<AudioSource> ().Play ();
            doubleJumpAllowed = false;
            
        }

      
    }
}
