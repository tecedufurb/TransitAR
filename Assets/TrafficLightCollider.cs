using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCollider : MonoBehaviour {   
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(GameManager.PLAYER_TAG)) {
            CNHManager.points -= CNHManager.POINTS_CLOSED_SEMAPHORE;
            print("semáforo: " + CNHManager.points);
        }
    }
}
