using UnityEngine;

public class LifeCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        CNHManager.points += CNHManager.POINTS_RELAX;
        print("pausa: " + CNHManager.points);
    }

    private void OnTriggerStay(Collider other) {
        if (CNHManager.life <= CNHManager.MAX_LIFE) {
            CNHManager.life += CNHManager.LIFE_RECHARGE;
        }
        print("pausa vida: " + CNHManager.life);
    }
}
