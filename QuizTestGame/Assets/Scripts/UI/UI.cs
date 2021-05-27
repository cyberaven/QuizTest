using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Field field;
    [SerializeField] private Text text;

    private Canvas canvas;

    public Field Field { get => field; }

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        field = Instantiate(Field, transform);    
    }
    public void ChangeText(string s)
    {
        text.text = "Find " + s;
    }
    

}
