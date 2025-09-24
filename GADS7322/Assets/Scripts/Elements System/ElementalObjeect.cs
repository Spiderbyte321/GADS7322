using System;
using UnityEngine;

public class ElementalObjeect : AElementalObject//base elemental platform
{
    [Header("Base Platform Components")]
    [SerializeField] private Collider2D collisionBox;
    [SerializeField] private Sprite revealedSprite;
    [SerializeField] private Sprite hiddenSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    protected override void ReactToElement(EElement ATypeToCheck)
    {
        if(CheckType(ATypeToCheck))
        {
            spriteRenderer.sprite = revealedSprite;
            collisionBox.isTrigger = false;
        }
        else
        {
            spriteRenderer.sprite = hiddenSprite;
            collisionBox.isTrigger = true;
        }
    }


    protected override void OnValidate()
    {
        if(spriteRenderer == null|| collisionBox == null|| revealedSprite==null|| hiddenSprite ==null)
            return;
        
        if(startActive)
        {
            spriteRenderer.sprite = revealedSprite;
            collisionBox.isTrigger = false;
        }
        else
        {
            spriteRenderer.sprite = hiddenSprite;
            collisionBox.isTrigger = true;
        }
    }
    
}
