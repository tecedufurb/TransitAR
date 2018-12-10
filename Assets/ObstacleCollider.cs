using UnityEngine;

public class ObstacleCollider : MonoBehaviour {    

    private void OnCollisionEnter(Collision collision) {
        //Feito pois a colisão de buracos é tratada na classe HoleCollider
        if (!collision.gameObject.CompareTag(GameManager.HOLE_TAG)) {
            CarManager.mechanic -= CarManager.MECHANIC_OBSTACLE_COLLIDER;
            print("obstáculo: " + CarManager.mechanic);
        }
    }
}
