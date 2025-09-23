using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private EElement[] elements;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Dictionary<EElement, Sprite> playerSprites = new Dictionary<EElement, Sprite>();

    public EElement[] Elements => elements;



    private void Awake()
    {
        for(int i=0;i<elements.Length;i++)
        {
            playerSprites.Add(elements[i],sprites[i]);
        }
    }
    
    public void SetSprite(EElement currentElement)
    {
        spriteRenderer.sprite = playerSprites[currentElement];
    }


    private void OnValidate()
    {
        if (sprites.Length > elements.Length)
        {
            Array.Resize(ref sprites,elements.Length);
            Debug.Log("too many sprites resized array");
        }
    }
}
