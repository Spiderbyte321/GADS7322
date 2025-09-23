using System;
using Managers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    
    [Header("Components")]
    [SerializeField] private ElementalDisplay[] playerDisplays;
    
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
}
