using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementalDisplay : MonoBehaviour
{
    [SerializeField] private EElement[] playerElements;
    [SerializeField] private SpriteRenderer[] ElementIcons;
    [SerializeField] private Color hiddenColor;
    [SerializeField] private Color normalColor;



    private Dictionary<EElement, bool> activeElement = new Dictionary<EElement, bool>();
    private Dictionary<EElement, SpriteRenderer> elementDictionary = new Dictionary<EElement, SpriteRenderer>();

    private void Awake()
    {
        for (int i = 0; i < playerElements.Length; i++)
        {
            elementDictionary.Add(playerElements[i],ElementIcons[i]);
            activeElement.TryAdd(playerElements[i], false);
        }
    }

    
    
    public void greyOutChosenElements(EElement[] givenElements)
    {
        foreach (KeyValuePair<EElement,bool> elements in activeElement)
        {
            activeElement[elements.Key] = false;
        }

        for(int i = 0; i < givenElements.Length; i++)
        {
            activeElement[givenElements[i]] = true;
        }
        
        foreach (KeyValuePair<EElement,bool> elements in activeElement)
        {
            elementDictionary[elements.Key].color = elements.Value ? hiddenColor : normalColor;
        }
    }
    
    
    


    private void OnValidate()
    {
        if(playerElements.Length < ElementIcons.Length)
        {
            Array.Resize(ref playerElements,ElementIcons.Length);
            Debug.Log("Not enough elements for the current icons resized array");
        }
    }
}
