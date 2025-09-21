using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lock : MonoBehaviour
{
    [SerializeField] private Key[] KeysToUnlock;

    private Dictionary<Key, bool> KeyContitions = new Dictionary<Key, bool>();


    private void OnEnable()
    {
        Key.KeyActivateAction += UpdateKeys;
        Key.KeyDeactivatedAction += UpdateKeys;
    }

    private void OnDisable()
    {
        Key.KeyActivateAction+= UpdateKeys;
        Key.KeyDeactivatedAction -= UpdateKeys;
    }

    private void Start()
    {
        foreach(Key key in KeysToUnlock)
        {
            KeyContitions.Add(key,false);
        }
    }


    private void UpdateKeys(Key key,bool condition)
    {
        if(KeyContitions.ContainsKey(key))
        {
            KeyContitions[key] = condition;
        }

        if(CheckKeys())
        {
            Unlock();
        }
    }

    protected virtual bool CheckKeys()
    {
        foreach(KeyValuePair<Key,bool> key in KeyContitions)
        {
            if(!KeyContitions[key.Key])
                return false;
        }

        return true;
    }

    protected virtual void Unlock()
    {
        throw new NotImplementedException("Implement unlock");
    }
    
}
