using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FieldCell : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private Image image;

    public void ChangeSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }


}
