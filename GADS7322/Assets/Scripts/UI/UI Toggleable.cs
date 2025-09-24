using System;
using Unity.VisualScripting;
using UnityEngine;

public class UIToggleable : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite toggledSprite;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected bool toggled = false;

    public virtual void Toggle()
    {
        toggled = !toggled;
        spriteRenderer.sprite = toggled ? toggledSprite : defaultSprite;
    }
    
    



}
