using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Field field;

    private Canvas canvas;

    public Field Field { get => field; }

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        field = Instantiate(Field, transform);    
    }
    

}
