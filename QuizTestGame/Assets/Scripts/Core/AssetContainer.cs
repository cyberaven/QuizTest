using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AssetName
{    
    Alphabet,
    Number
}
public class AssetContainer : MonoBehaviour
{
    [SerializeField] private AssetName assetName;
    [SerializeField] private List<Sprite> sprites;
}
