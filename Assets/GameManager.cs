using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Configuração de tempo
    public static int SECONDS_CHANGE_TRAFFIC_LIGHT = 10;
    public static int SECONDS_CHANGE_HOLES = 10;

    //Quantidade de alcool quando clicar notificação. Altera o tempo que a imagem fica dificultada
    public static int ALCOOL_QUANTITY = 1000;

    //Menu
    public static string MENU_METHOD = "Menu";

    //Data de mudança dos semáforo
    private DateTime changedTrafficLight;

    //Buracos
    private DateTime changedHole;
    private Renderer[] holes;
    public Transform hole;
    public Material visible;
    public Material invisible;

    //Notificações
    public String[] messages;
    private System.Random random = new System.Random();

    //Alcool
    public Sprite visao;
    public Sprite visaoDificultada;
    public static Sprite staticVisaoNormal;
    public static Sprite staticVisaoDificultada;
    private static int alcoolQuantity = 0;
    public static bool alcool = false;
    public Image imagem;

    //TAGs
    public static string PLAYER_TAG = "Player";
    public static string HOLE_TAG = "Hole";

    public static bool joystick = false;

    void Start () {
        changedTrafficLight = DateTime.Now;
        changedHole = DateTime.Now;

        holes = hole.GetComponentsInChildren<Renderer>();

        staticVisaoNormal = visao;
        staticVisaoDificultada = visaoDificultada;

    }
	
	// Update is called once per frame
	void Update () {
        if (DateTime.Compare(changedHole.AddSeconds(SECONDS_CHANGE_HOLES), DateTime.Now) < 0) {
            changeHoles();
        }

        if(1 == random.Next(1, 2000)){
            sendRandomNotification();
        }
        
        if (alcoolQuantity > 0) {
            staticVisaoNormal = visaoDificultada;
            alcoolQuantity--;
            alcool = true;
        } else {
            staticVisaoNormal = visao;
            alcool = false;
        }

        if (CNHManager.points <= 0) {
            MyNotifications.CallNotification(MyNotifications.LOST_ALL_POINTS_MESSAGE, 3);
            Invoke(MENU_METHOD, 3);
        }

        if (CNHManager.life <= 0) {
            MyNotifications.CallNotification(MyNotifications.LOST_ALL_LIFE_MESSAGE, 3);
            Invoke(MENU_METHOD, 3);
        }

        if (CarManager.fuel <= 0) {
            MyNotifications.CallNotification(MyNotifications.LOST_ALL_FUEL_MESSAGE, 3);
            Invoke(MENU_METHOD, 3);
        }

        if (CarManager.mechanic <= 0) {
            MyNotifications.CallNotification(MyNotifications.LOST_ALL_MECHANIC_MESSAGE, 3);
            Invoke(MENU_METHOD, 3);
        }

        CNHManager.life -= 1;
        imagem.sprite = staticVisaoNormal;
    }

    void changeHoles() {
        foreach(Renderer hole in holes) {            
            hole.material = (1 == random.Next(0, 10)) ? visible : invisible;
        }
        changedHole = DateTime.Now;
    }

    void sendRandomNotification() {
        int index = random.Next(0, messages.Length);
        String mensagem = messages[index];
        MyNotifications.CallNotification(mensagem, 3);
    }

    public static void notificationClicked(string mensagemNotificacao) {    
        if (mensagemNotificacao.Contains("cerveja")) {
            //Descontar mais pontos e dificultar jogabilidade temporariamente
            staticVisaoNormal = staticVisaoDificultada;
            alcoolQuantity += ALCOOL_QUANTITY;
            CNHManager.life -= CNHManager.LIFE_DRINK_ALCOOL;
            CNHManager.points -= CNHManager.POINTS_DRINK_ALCOOL;
        } else {
            //Somente descontar pontos  
            if (CarMove.m_MovementInputValue > 0) {
                CNHManager.points -= CNHManager.POINTS_CLICK_NOTIFICATION;
            }
        }
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
