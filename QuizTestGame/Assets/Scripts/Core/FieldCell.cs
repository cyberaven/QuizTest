using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FieldCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool right;
    [SerializeField] private Image image;

    public delegate void UserOnRightFieldCellDel();
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
            UserOnRightFieldCellEve?.Invoke();
        }
    }
}
