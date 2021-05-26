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
        for (int i = 0; i < count; i++)
        {
            FieldCell f = Instantiate(fieldCell, transform);
            currentFieldCells.Add(f);
        }
    }

    public void FillField(List<Sprite> selectedSprites)
    {
        for (int i = 0; i < currentFieldCells.Count; i++)
        {
            currentFieldCells[i].ChangeSprite(selectedSprites[i]);
        }        
    }
}
