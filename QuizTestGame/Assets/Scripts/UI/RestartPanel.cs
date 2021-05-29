using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class RestartPanel : Panel
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();        
    }

    public override void On()
    {
        image.DOFade(255, 3);
        transform.SetAsLastSibling();
        base.On();
    }
    public override void Off()
    {
        image.color = new Color(31, 31, 31, 0);
        base.Off();
    }

}
