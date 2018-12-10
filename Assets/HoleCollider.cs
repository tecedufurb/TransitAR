using UnityEngine;

public class HoleCollider : MonoBehaviour {
    public Material visible;
    public Material invisible;
    private Renderer[] renderers;

    // Use this for initialization
    void Start () {
        renderers = transform.GetComponentsInChildren<Renderer>();
    }

    private void OnCollisionEnter(Collision collision) {
        //Utilizei a textura pois o name do visible era sempre (instance)
        if (renderers[0].material.mainTexture.Equals(visible.mainTexture) && collision.gameObject.CompareTag(GameManager.PLAYER_TAG)) {
            CarManager.mechanic -= CarManager.MECHANIC_HOLE_COLLIDER;
            print("buraco: " + CarManager.mechanic);
        }
    }
}
