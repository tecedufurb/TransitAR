using UnityEngine;

public class GasStationCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        CNHManager.points += CNHManager.POINTS_GAS_STATION;
        print("posto: " + CNHManager.points);
    }

    private void OnTriggerStay(Collider other) {
        if(CarManager.fuel <= CarManager.MAX_FUEL) {
            CarManager.fuel += CarManager.FUEL_RECHARGE;
        }
        print("abastecendo: " + CarManager.fuel);
    }
}
