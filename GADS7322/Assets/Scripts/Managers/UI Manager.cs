using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    
    [Header("Components")]
    [SerializeField] private ElementalDisplay[] playerDisplays;

    [SerializeField] private UIToggleable[] togglesInput;
    [SerializeField] private Key[] keysInput;

    private Dictionary<Key, UIToggleable> togglesDictionary = new Dictionary<Key, UIToggleable>();


    private void Awake()
    {
        for (int i = 0; i < togglesInput.Length; i++)
        {
            togglesDictionary.Add(keysInput[i],togglesInput[i]);
        }
    }

    private void OnEnable()
    {
        GameManager.OnAllElements += UpdateDisplays;
    }

    private void OnDisable()
    {
        GameManager.OnAllElements -= UpdateDisplays;
    }

    private void UpdateDisplays(EElement[] elements)
    {
        foreach (ElementalDisplay display in playerDisplays)
        {
            display.greyOutChosenElements(elements);
        }
    }

    private void OnValidate()
    {
        if(keysInput.Length < togglesInput.Length)
        {
          Array.Resize(ref keysInput,togglesInput.Length);
          Debug.Log("not enough keys resized keys array");
        }
    }
}
