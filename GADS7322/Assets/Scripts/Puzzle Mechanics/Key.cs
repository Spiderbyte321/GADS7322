using System;
using UnityEngine;

public abstract class Key : MonoBehaviour
{
    public delegate void KeyActivated(Key AKey,bool condition);

    public static event KeyActivated KeyActivateAction;

    public delegate void KeyDeactivated(Key Akey,bool condition);
    
    public static event KeyDeactivated KeyDeactivatedAction;
    


    protected void Activate()
    {
        KeyActivateAction?.Invoke(this,true);
    }

    protected void Deactivate()
    {
        KeyDeactivatedAction?.Invoke(this,false);
    }

    private void Start()
    {
       Deactivate();
    }
}
