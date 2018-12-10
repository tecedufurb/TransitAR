using UnityEngine;

public class PedestrianCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag(GameManager.PLAYER_TAG)) {
            CNHManager.points = CNHManager.REMOVE_ALL_POINTS;
            MyNotifications.CallNotification(MyNotifications.RUN_OVER_PEDESTRIAN_MESSAGE, 10);
        }
    }
}
