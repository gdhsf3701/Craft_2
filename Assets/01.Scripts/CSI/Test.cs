using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Test : MonoBehaviour
{
 [SerializeField] private GameObject Target;

 private void Update()
 {
  transform.position = new Vector3(Target.transform.position.x  , Target.transform.position.y , transform.position.z);
 } 
}
