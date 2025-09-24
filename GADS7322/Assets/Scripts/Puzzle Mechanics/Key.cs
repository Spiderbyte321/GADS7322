using System;
using UnityEngine;

public abstract class Key : MonoBehaviour
{
    public delegate void KeyActivated(Key AKey,bool condition);

    public static event KeyActivated KeyActivateAction;

    public delegate void KeyDeactivated(Key Akey,bool condition);
    
    public static event KeyDeactivated KeyDeactivatedAction;

    public delegate void KeyToggledAction(Key AKey);

    public static event KeyToggledAction OnKeyToggled;


    protected void Activate()
    {
        KeyActivateAction?.Invoke(this,true);
        OnKeyToggled?.Invoke(this);
    }

    protected void Deactivate()
    {
        KeyActivateAction?.Invoke(this,false);
        OnKeyToggled?.Invoke(this);
    }
}
