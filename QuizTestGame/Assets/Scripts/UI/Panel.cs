using System.Collections;
using UnityEngine;


public class Panel : MonoBehaviour
{
    public virtual void On()
    {
        gameObject.SetActive(true);
    }
    public virtual void Off()
    {
        gameObject.SetActive(false);
    }
}
