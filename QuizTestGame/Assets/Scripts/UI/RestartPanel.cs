using System.Collections;
using UnityEngine;


public class RestartPanel : Panel
{      
    public void On()
    {
        transform.SetAsLastSibling();
        base.On();
    }
}
