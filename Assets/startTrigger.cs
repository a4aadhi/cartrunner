using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTrigger : MonoBehaviour
{
   public GameHandler gameHandler;
    private void OnTriggerEnter(Collider other) {
       gameHandler.StartTimer();
   }
}
