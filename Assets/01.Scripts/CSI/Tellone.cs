using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tellone : MonoBehaviour
{
   private GameObject Start, End;

   private void Awake()
   {
      Start = gameObject;
      End = transform.root.transform.Find("End").gameObject;
      
      
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.transform.root.name == "Player")
      {
         StartCoroutine(Wait(other));
      }
   }

   IEnumerator Wait(Collider2D other)
   {
      FadeManager.instance.FadeIn(1f);
      yield return new WaitForSeconds(2f);
      other.transform.position = End.transform.position;
      yield return new WaitForSeconds(1f);
      FadeManager.instance.FadeOut(2f);
   }  
}
