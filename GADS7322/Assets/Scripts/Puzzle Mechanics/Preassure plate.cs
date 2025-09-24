using System;
using Unity.VisualScripting;
using UnityEngine;

public class Preassureplate : Key
{
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      Activate();
   }


   private void OnTriggerExit2D(Collider2D other)
   {
      Deactivate();
   }
   
}
