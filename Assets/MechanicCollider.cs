using UnityEngine;

public class MechanicCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        CNHManager.points += CNHManager.POINTS_AUTO_REPAIR;
        print("oficina: " + CNHManager.points);
    }

    private void OnTriggerStay(Collider other) {
        if(CarManager.mechanic < CarManager.MAX_MECHANIC) {
            CarManager.mechanic += CarManager.MECHANIC_RECHARGE;
            print("oficina mecanica: " + CarManager.mechanic);
        }
    }
    
}
