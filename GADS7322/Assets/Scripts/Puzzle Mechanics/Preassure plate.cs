using System;
using UnityEngine;

public class Preassureplate : Key
{
   [SerializeField] private Sprite pressedDown;
   [SerializeField] private Sprite pressedUp;
   [SerializeField] private SpriteRenderer spriteRenderer;
   
   
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      spriteRenderer.sprite = pressedDown;
      Activate();
   }


   private void OnTriggerExit2D(Collider2D other)
   {
      spriteRenderer.sprite = pressedUp;  
      Deactivate();
   }
}
