using UnityEngine;

public class SideWalkCollider : MonoBehaviour {
    
    private void OnTriggerStay(Collider other) {
        CNHManager.points -= CNHManager.POINTS_SIDE_WALK;
        print("calçada: " + CNHManager.points);
    }

    private void OnTriggerEnter(Collider other) {
        CarManager.mechanic -= CarManager.MECHANIC_SIDE_WALK;
        print("calçada: " + CarManager.mechanic);
    }
    
}
