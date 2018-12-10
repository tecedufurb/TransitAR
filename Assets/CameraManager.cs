using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject[] cameras;

    void Start() {
        foreach(GameObject camera in cameras){
            camera.SetActive(false);
        }

        cameras[0].SetActive(true);
    }

    public void changeCamera() {
        foreach(GameObject camera in cameras) {
            camera.SetActive(!camera.activeSelf);
        }
    }

}
