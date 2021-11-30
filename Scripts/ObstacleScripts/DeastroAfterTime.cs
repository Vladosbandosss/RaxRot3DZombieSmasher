using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeastroAfterTime : MonoBehaviour
{
   public float timer = 3f;

   private void Start()
   {
      Invoke(nameof(DeactivateGameObject),timer);
   }

   void DeactivateGameObject()
   {
      gameObject.SetActive(false);
   }
}
