using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Field field;
    [SerializeField] private Text text;
    [SerializeField] private RestartPanel restartPanel;

    private Canvas canvas;

    public Field Field { get => field; }
    public RestartPanel RestartPanel { get => restartPanel; }

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
