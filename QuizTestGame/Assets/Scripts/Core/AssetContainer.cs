using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssetContainer : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<string> valueForText;
    [SerializeField] private List<int> usedSprites = new List<int>();

    public AnswerContainer GetRandomSprites(int spritesCount)
    {        
        AnswerContainer answerContainer = new AnswerContainer();
        int rightAnswerIndex = UnityEngine.Random.Range(0, spritesCount);
        List<int> currentRandIndex = new List<int>();

        for (int i = 0; i < spritesCount; i++)
        {
            int ri = GetUnusedRandomIndex(sprites, currentRandIndex);
            currentRandIndex.Add(ri);
            answerContainer.sprites.Add(sprites[ri]);
            answerContainer.valueForText.Add(valueForText[ri]);
            if(rightAnswerIndex == i)
            {
                answerContainer.rightIndex = rightAnswerIndex;
                usedSprites.Add(ri);
            }
        }

        return answerContainer;
    }
    private int GetUnusedRandomIndex(List<Sprite> sprites, List<int> currentRandIndex)
    {
        int i = UnityEngine.Random.Range(0, sprites.Count);        
        while(usedSprites.Contains(i) || currentRandIndex.Contains(i))
        {
            i = UnityEngine.Random.Range(0, sprites.Count);           
        }        
        return i;
    }  
    public void ResetUsedAnswer()
    {
        usedSprites = new List<int>();
    }
}
public class AnswerContainer
{
    public List<Sprite> sprites = new List<Sprite>();    
    public List<string> valueForText = new List<string>();
    public int rightIndex = 0;
}
