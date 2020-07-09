using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            transform.position = gm.lastCPPos;
        }
    }
}
