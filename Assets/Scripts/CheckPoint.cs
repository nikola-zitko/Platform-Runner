using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public Sprite mySprite;
    private GameMaster gm;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other){
        this.GetComponent<SpriteRenderer>().sprite = mySprite;
        if(other.CompareTag("Player")){
            gm.lastCPPos = transform.position;
        }
        
    }
}
