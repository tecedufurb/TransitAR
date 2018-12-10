using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    private string GAME_SCENE = "Jogo";
    private string URL_LAWS = "https://tecedufurb.github.io/TransitAR/leis";
    private string URL_ABOUT = "https://tecedufurb.github.io/TransitAR/about";

    public void Jogar() {
        CNHManager.beltFastened = false;
        CarMove.movementValue = 0;
        
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void Quit() {
        Application.Quit();
    }

    public void ShowLaw() {
        Application.OpenURL(URL_LAWS);
    }

    public void ShowAbout() {
        Application.OpenURL(URL_ABOUT);
    }
}
