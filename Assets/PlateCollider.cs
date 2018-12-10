using UnityEngine;

public class PlateCollider : MonoBehaviour {
    public int velocity;

    private void OnTriggerEnter(Collider other) {
        if(SpeedoMeterScript.velocityInt > velocity) {
            CNHManager.points -= CNHManager.POINTS_ABOVE_SPEED;
        } else {
            CNHManager.points += CNHManager.POINTS_RESPECT_SPEED;
        }
    }
}
