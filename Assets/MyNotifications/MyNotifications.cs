using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyNotifications : MonoBehaviour {
	public static Texture texture;
	public Texture notificationTexture;
	public static float timer = 0.0f;
	private static bool callNotification = false;
	private static string message;
	public static GUIStyle textStyle;
	public GUIStyle myStyle;

	public static Vector2 notificationSize;
	public Vector2 startinPos,endPos,size;
	public static Vector2 startingPosition;
	public static Vector2 wantedPosition;
	public static Vector2 currentPos;
	private static Vector3 velocity3;
	public AudioSource ourSound;
	public static AudioSource audioSource;

    public static string SEAT_BELT_MESSAGE = "Parabéns por utilizar o Cinto de segurança";
    public static string LOST_ALL_POINTS_MESSAGE = "Você perdeu todos os pontos!";
    public static string RUN_OVER_PEDESTRIAN_MESSAGE = "Você perdeu por atropelar o pedestre!";
    public static string LOST_ALL_FUEL_MESSAGE = "Você perdeu por ficar sem combustível!";
    public static string LOST_ALL_MECHANIC_MESSAGE = "Você perdeu por danificar seu veículo!";
    public static string LOST_ALL_LIFE_MESSAGE = "Você perdeu por não descansar!";
    public static string WELCOME_MESSAGE = "Bem vindo ao jogo!";

    void Start(){
		audioSource = ourSound;
		startingPosition = startinPos;
		wantedPosition = endPos;
		notificationSize = size;
		currentPos = startingPosition;
		texture = notificationTexture;
		textStyle = myStyle;
        clear();

    }
	private  static bool pushNotification(string _message,float _duration){
        if (timer <= 0)
        {
            timer = _duration;
            audioSource.Play();
        }
        else
        {
            if (timer < 1)
                currentPos = Vector3.SmoothDamp(currentPos, startingPosition, ref velocity3, 0.35f);
            else
                currentPos = Vector3.SmoothDamp(currentPos, wantedPosition, ref velocity3, 0.35f);

            GUI.DrawTexture(new Rect(currentPos.x, currentPos.y, 300, notificationSize.y), texture);
            if (GUI.Button(new Rect(currentPos.x, currentPos.y, 300, notificationSize.y), _message.ToString(), textStyle))
            {       
                GameManager.notificationClicked(_message);
            }

            timer -= 0.5f * Time.deltaTime;
            if (timer <= 0)
            {
                listaNotifikacija.RemoveAt(0);
                listaTimera.RemoveAt(0);
                if (listaNotifikacija.Count == 0)
                {
                    return false;
                }
                else
                {
                    CallAgain();
                }
            }
            return true;
        }
        return true;
    }

    
	public static List<string> listaNotifikacija = new List<string>();
	public static List<float> listaTimera = new List<float>();
	
	public static void CallNotification(string _message,float _duration){
		listaNotifikacija.Add(_message);
		listaTimera.Add(_duration);

		if(callNotification == false)
			callNotification = pushNotification(listaNotifikacija[0],listaTimera[0]);
	}
	
	private static void CallAgain(){
		if(listaNotifikacija.Count != 0){
			callNotification = pushNotification(listaNotifikacija[0],listaTimera[0]);
		}
	}

	void OnGUI(){
		if(callNotification){
            try {
                callNotification = pushNotification(listaNotifikacija[0], listaTimera[0]);
            } catch {

            }			
		}
	}

    public static void clear() {
        listaNotifikacija.Clear();
        listaTimera.Clear();
        
    }
}