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

    public Sprite GetRandomSprites()
    {
        return sprites[UnityEngine.Random.Range(0, sprites.Count)];
    }
}
