using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Starter : MonoBehaviour
{    
    [SerializeField] private StateMashine stateMashine;
    [SerializeField] private GameCore gameCore;    
     

    private void Awake()
    {        
        gameCore = Instantiate(gameCore);
        stateMashine = Instantiate(stateMashine);
    }
    private void Start()
    {        
        stateMashine.Init();
    }
}
