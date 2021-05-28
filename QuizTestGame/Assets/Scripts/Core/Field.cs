using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Panel
{
    [SerializeField] private FieldCell fieldCell;
    [SerializeField] private List<FieldCell> currentFieldCells;

    public void CreateCell(int count)
    {       
        if(count > currentFieldCells.Count)
        {
            count -= currentFieldCells.Count;
        }
        else if(count < currentFieldCells.Count)
        {
            foreach(FieldCell fieldCell in currentFieldCells)
            {
                Destroy(fieldCell.gameObject);
            }
            currentFieldCells = new List<FieldCell>();
        }

        for (int i = 0; i < count; i++)
        {
            FieldCell f = Instantiate(fieldCell, transform);
            currentFieldCells.Add(f);
        }
    }

    public void FillField(AnswerContainer answerContainer)
    {
        for (int i = 0; i < currentFieldCells.Count; i++)
        {
            Sprite sprite = answerContainer.sprites[i];
            bool right = false;
            if(i == answerContainer.rightIndex)
            {
                right = true;
            }
            currentFieldCells[i].ChangeSprite(sprite, right);
        }        
    }
}
