using System;
using UnityEngine;

public class Preassureplate : Key
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log("Entered");
      Activate();
   }


   private void OnTriggerExit2D(Collider2D other)
   {
      Deactivate();
   }
}
