using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateName
{
    Prepare,
    PickRandomAsset,
    CheckCurrentDifficulty,    
    WaitRightAnswer,
    RestartGame,
    FillField,
    ChangeDifficulty,
    CreateField
}

public class StateMashine : MonoBehaviour
{
    [SerializeField] private GameStateName currentState;    

    public delegate void GameStateChangedDel(GameStateName gameStateName);
    public static event GameStateChangedDel GameStateChangedEve;

    private void OnEnable()
    {
        GameCore.ChangeStateEve += ChangeState;
    }
    private void OnDisable()
    {
        GameCore.ChangeStateEve -= ChangeState;
    }

    public void Init()
    {
        ChangeState(GameStateName.Prepare);
    }

    private void ChangeState(GameStateName gameStateName)
    {
        currentState = gameStateName;
        Debug.Log("Current state: " + currentState);
        GameStateChangedEve?.Invoke(gameStateName);        
    }   
}
