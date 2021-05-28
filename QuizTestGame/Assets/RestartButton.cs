using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RestartButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void RestartButtonClkDel();
    public static event RestartButtonClkDel RestartButtonClkEve;

    public void OnPointerClick(PointerEventData eventData)
    {
        RestartButtonClkEve?.Invoke();
    }
}
