using UnityEngine;
using System.Collections.Generic;
using Managers;

public class GreyOutPlatform : AElementalObject
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hiddenColor;
    [SerializeField] private Collider2D collisionBox;
    [SerializeField] private SpriteRenderer spriteRenderer;


    protected override void OnEnable()
    {
        GameManager.OnAllElements += ReactToElement;
    }

    protected override void OnDisable()
    {
        GameManager.OnAllElements -= ReactToElement;
    }


    private void ReactToElement(EElement[] ATypeToCheck)
    {
        bool oneTrue = false;

        List<bool> elementSimilar = new List<bool>();
        
        for(int i = 0; i < ATypeToCheck.Length; i++)
        {
            if(CheckType(ATypeToCheck[i]))
            {
                elementSimilar.Add(true);  
            }
            else
            {
                elementSimilar.Add(false);
            }
        }

        foreach(bool isTrue in elementSimilar)
        {
            if(isTrue)
                oneTrue = true;
        }
        

        if(oneTrue)
        {
            Debug.Log($"enabling collision on {this}:{objectElement}");
            collisionBox.isTrigger = false;
            spriteRenderer.color = defaultColor;
        }
        else
        {
            collisionBox.isTrigger = true;
            spriteRenderer.color = hiddenColor;
        }
    }
    
    
}
