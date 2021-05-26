using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameDifficulty
{
    Easy,
    Normal,
    Hard
}

public class GameCore : MonoBehaviour
{
    [SerializeField] private GameDifficulty currentGameDifficulty;
    [SerializeField] private int fieldCellCountEasyDif = 3;
    [SerializeField] private int fieldCellCountNormalDif = 6;
    [SerializeField] private int fieldCellCountHardDif = 9;

    [SerializeField] private Field field;
    [SerializeField] private List<AssetContainer> assetContainers;


    public delegate void ChangeStateDel(GameStateName gameStateName);
    public static event ChangeStateDel ChangeStateEve;

    private void OnEnable()
    {
        StateMashine.GameStateChangedEve += GameStateChanged;
    }
    private void OnDisable()
    {
        StateMashine.GameStateChangedEve -= GameStateChanged;
    }

    private void GameStateChanged(GameStateName gameStateName)
    {
        if(gameStateName == GameStateName.Prepare)
        {
            field = Instantiate(field);
            ChangeStateEve?.Invoke(GameStateName.CreateEasyField);
        }
        if(gameStateName == GameStateName.CreateEasyField)
        {
            CreateField(currentGameDifficulty);
        }
    }

    private void CreateField(GameDifficulty gameDifficulty)
    {
        if(gameDifficulty == GameDifficulty.Easy)
        {
            field.CreateCell(fieldCellCountEasyDif);
        }
    }
}
