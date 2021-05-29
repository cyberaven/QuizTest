using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Field : Panel
{    
    [SerializeField] private List<FieldCell> currentFieldCells;

    public void CreateCell(int count)
    {        
        ClearAllCell();
        HideAllCell();
        ShowCell(count);
    }

    private void ShowCell(int count)
    {
        for (int i = 0; i < count; i++)
        {
            currentFieldCells[i].gameObject.SetActive(true);
            currentFieldCells[i].transform.DOShakeScale(1);            
        }
    }
    private void ClearAllCell()
    {
        foreach (FieldCell fieldCell in currentFieldCells)
        {
            fieldCell.Clear();
        }
    }
    private void HideAllCell()
    {
        foreach (FieldCell fieldCell in currentFieldCells)
        {
            fieldCell.gameObject.SetActive(false);
        }
    }

    public void FillField(AnswerContainer answerContainer)
    {
        for (int i = 0; i < currentFieldCells.Count; i++)
        {
            if(currentFieldCells[i].gameObject.activeSelf)
            {
                Sprite sprite = answerContainer.sprites[i];
                bool right = false;
                if (i == answerContainer.rightIndex)
                {
                    right = true;
                }
                currentFieldCells[i].ChangeSprite(sprite, right);
            }            
        }        
    }
}
