using Managers;
using UnityEngine;
using System.Collections.Generic;

public class ElementalPreassurePlate : AElementalObject
{

    [SerializeField] private Collider2D collisionBox;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color inactiveColor;


    protected override void OnEnable()
    {
        GameManager.OnAllElements += ReactToPlayers;
    }

    protected override void OnDisable()
    {
        GameManager.OnAllElements -= ReactToPlayers;
    }

    private void ReactToPlayers(EElement[] ATypeToCheck)
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
            collisionBox.enabled = true;
            spriteRenderer.color = defaultColor;
        }
        else
        {
            collisionBox.enabled = false;
            spriteRenderer.color = inactiveColor;
        }
    }
    
}
