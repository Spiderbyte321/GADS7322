using UnityEngine;

public class GreyOutPlatform : AElementalObject
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hiddenColor;
    [SerializeField] private Collider2D collisionBox;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    protected override void ReactToElement(EElement ATypeToCheck)
    {
        if(CheckType(ATypeToCheck))
        {
            spriteRenderer.color = defaultColor;
            collisionBox.isTrigger = false;
        }
        else
        {
            spriteRenderer.color = hiddenColor;
            collisionBox.isTrigger = true;
        }
    }
    
    
}
