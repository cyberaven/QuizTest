using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameDifficulty
{
    Easy = 0,
    Normal = 1,
    Hard = 2
}

public class GameCore : MonoBehaviour
{
    [SerializeField] private GameDifficulty currentGameDifficulty;
    [SerializeField] private int fieldCellCountEasyDif = 3;
    [SerializeField] private int fieldCellCountNormalDif = 6;
    [SerializeField] private int fieldCellCountHardDif = 9;

    [SerializeField] private Field field;
    [SerializeField] private List<AssetContainer> assetContainers;
    [SerializeField] private int selectedAssetContainer;
    [SerializeField] private List<Sprite> selectedSprites;
    [SerializeField] private AnswerContainer answerContainer;

    private UI ui;

    public delegate void ChangeStateDel(GameStateName gameStateName);
    public static event ChangeStateDel ChangeStateEve;

    private void OnEnable()
    {
        StateMashine.GameStateChangedEve += GameStateChanged;
        FieldCell.UserOnRightFieldCellEve += UserOnRightFieldCell;
        RestartButton.RestartButtonClkEve += RestartButtonClk;
            
    }
    private void OnDisable()
    {
        StateMashine.GameStateChangedEve -= GameStateChanged;
        FieldCell.UserOnRightFieldCellEve -= UserOnRightFieldCell;
        RestartButton.RestartButtonClkEve -= RestartButtonClk;
    }

    public void Init(UI ui)
    {
        this.ui = ui;
    }

    private void GameStateChanged(GameStateName gameStateName)
    {
        if(gameStateName == GameStateName.Prepare)
        {
            currentGameDifficulty = GameDifficulty.Easy;
            ui.RestartPanel.Off();
            ResetUsedAnswer(assetContainers);
            ChangeStateEve?.Invoke(GameStateName.CreateField);
        }
        if(gameStateName == GameStateName.CreateField)
        {
            CreateField(currentGameDifficulty);
            ChangeStateEve?.Invoke(GameStateName.PickRandomAsset);
        }
        if(gameStateName == GameStateName.PickRandomAsset)
        {
            PickRandomAsset(assetContainers);
            PickRandomImage(selectedAssetContainer);
            ChangeStateEve?.Invoke(GameStateName.FillField);
        }
        if(gameStateName == GameStateName.FillField)
        {
            ui.Field.FillField(answerContainer);
            string findText = answerContainer.valueForText[answerContainer.rightIndex];
            ui.ChangeText(findText);
        }
        if(gameStateName == GameStateName.ChangeDifficulty)
        {
            if (currentGameDifficulty == GameDifficulty.Hard)
            {
                ui.RestartPanel.On();
            }
            else
            {
                ChangeNextDifficulty(currentGameDifficulty);
                ChangeStateEve?.Invoke(GameStateName.CreateField);
            }
        }
        if (gameStateName == GameStateName.RestartGame)
        {
            currentGameDifficulty = GameDifficulty.Easy;
            ui.RestartPanel.Off();
            ChangeStateEve?.Invoke(GameStateName.CreateField);
        }
    }
    private void ChangeNextDifficulty(GameDifficulty currentGameDifficulty)
    {
        if(currentGameDifficulty == GameDifficulty.Easy)
        {
            this.currentGameDifficulty = GameDifficulty.Normal;
        }
        else if (currentGameDifficulty == GameDifficulty.Normal)
        {
            this.currentGameDifficulty = GameDifficulty.Hard;
        }
        Debug.Log("Current Difficulty: " + this.currentGameDifficulty);
    }

    private void PickRandomAsset(List<AssetContainer> assetContainers)
    {
        selectedAssetContainer = UnityEngine.Random.Range(0, assetContainers.Count);
    }
    private void PickRandomImage(int selectedAssetContainer)
    {
        answerContainer = null;
        AssetContainer assetContainer = assetContainers[selectedAssetContainer];
        int spriteCount = DifficultyElementCount(currentGameDifficulty);
        answerContainer = assetContainer.GetRandomSprites(spriteCount);
    }    

    private void CreateField(GameDifficulty gameDifficulty)
    {
        int fieldCellCount = DifficultyElementCount(gameDifficulty);
        ui.Field.CreateCell(fieldCellCount);        
    }

    private int DifficultyElementCount(GameDifficulty gameDifficulty)
    {
        if (gameDifficulty == GameDifficulty.Easy)
        {
            return fieldCellCountEasyDif;            
        }
        if (gameDifficulty == GameDifficulty.Normal)
        {
            return fieldCellCountNormalDif;            
        }
        if (gameDifficulty == GameDifficulty.Hard)
        {
            return fieldCellCountHardDif;            
        }
        throw new Exception("No gameDifficulty: " + gameDifficulty);
    }

    private void UserOnRightFieldCell()
    {
        ChangeStateEve?.Invoke(GameStateName.ChangeDifficulty);
    }
    private void ResetUsedAnswer(List<AssetContainer> assetContainers)
    {
        foreach (AssetContainer assetContainer in assetContainers)
        {
            assetContainer.ResetUsedAnswer();
        }
    }
    private void RestartButtonClk()
    {
        ChangeStateEve?.Invoke(GameStateName.RestartGame);
    }
}
