using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    private void Start()
    {
        text.DOFade(255, 10);
    }

    public void ChangeText(string s)
    {        
        text.text = "Find " + s;
    }
    

}
