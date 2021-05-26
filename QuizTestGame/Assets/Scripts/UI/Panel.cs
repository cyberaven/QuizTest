using System.Collections;
using UnityEngine;


public class Panel : MonoBehaviour
{
    public void On()
    {
        gameObject.SetActive(true);
    }
    public void Off()
    {
        gameObject.SetActive(false);
    }
}
