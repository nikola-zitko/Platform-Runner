using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    
    private GameMaster gm;
    private GameObject player;
    
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D border){
        
        if(border.CompareTag("Player")){
            player.transform.position = gm.lastCPPos;
        }
        
    }
}
