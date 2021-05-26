using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Starter : MonoBehaviour
{    
    [SerializeField] private StateMashine stateMashine;
    [SerializeField] private GameCore gameCore;
    [SerializeField] private UI ui;
     

    private void Awake()
    {
        ui = Instantiate(ui);
        gameCore = Instantiate(gameCore);
        stateMashine = Instantiate(stateMashine);
    }
    private void Start()
    {
        gameCore.Init(ui);
        stateMashine.Init();
    }
}
