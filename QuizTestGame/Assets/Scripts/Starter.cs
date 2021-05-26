using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private StateMashine stateMashine;

    private void Awake()
    {
        stateMashine = Instantiate(stateMashine);
    }
}
