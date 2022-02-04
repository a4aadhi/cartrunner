using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTrigger : MonoBehaviour
{
    public GameHandler gameHandler;
    private void OnTriggerEnter(Collider other) {
       gameHandler.StopTimer();
    }
}
