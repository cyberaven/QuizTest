using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class FieldCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool right;
    [SerializeField] private Image image;

    public delegate void UserOnRightFieldCellDel(FieldCell fieldCell);
    public static event UserOnRightFieldCellDel UserOnRightFieldCellEve;

    public void ChangeSprite(Sprite sprite, bool right)
    {
        image.sprite = sprite;
        this.right = right;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (right)
        {                      
            UserOnRightFieldCellEve?.Invoke(this);
        }
        else
        {
            image.transform.DOShakePosition(2, 10, 10, 0);
        }
    }

    private void ShowStars()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        right = false;
        image.sprite = null;
    }
}
