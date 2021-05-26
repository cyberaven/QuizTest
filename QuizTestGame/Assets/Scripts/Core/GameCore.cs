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
    [SerializeField] private int selectedAssetContainer;
    [SerializeField] private List<Sprite> selectedSprites;

    private UI ui;

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

    public void Init(UI ui)
    {
        this.ui = ui;
    }

    private void GameStateChanged(GameStateName gameStateName)
    {
        if(gameStateName == GameStateName.Prepare)
        {            
            ChangeStateEve?.Invoke(GameStateName.CreateEasyField);
        }
        if(gameStateName == GameStateName.CreateEasyField)
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
            ui.Field.FillField(selectedSprites);
        }
    }

    private void PickRandomAsset(List<AssetContainer> assetContainers)
    {
        selectedAssetContainer = UnityEngine.Random.Range(0, assetContainers.Count);
    }
    private void PickRandomImage(int selectedAssetContainer)
    {
        selectedSprites = new List<Sprite>();
        AssetContainer assetContainer = assetContainers[selectedAssetContainer];
        int spriteCount = DifficultyElementCount(currentGameDifficulty);

        for (int i = 0; i < spriteCount; i++)
        {
            selectedSprites.Add(assetContainer.GetRandomSprites());
        }
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
}
