using System;
using UnityEngine;

public class DoorTogglable : UIToggleable
{
    [SerializeField] private Key ConnectedKey;
    
    private void OnEnable()
    {
        Key.KeyActivateAction += Toggle;
        Key.KeyDeactivatedAction += Toggle;
    }

    private void OnDisable()
    {
        Key.KeyActivateAction -= Toggle;
        Key.KeyDeactivatedAction -= Toggle;
    }

    private void Toggle(Key Akey,bool isActive)
    {
        toggled = isActive;
        if(ConnectedKey!=Akey)
            return;
        
        Toggle();
    }

    public override void Toggle()
    {
        spriteRenderer.enabled = toggled;
    }
}
