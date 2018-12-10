using UnityEngine.UI;
using UnityEngine;

public class CNHManager : MonoBehaviour {
    //Points
    public static float START_POINTS = 1000;    
    public static float POINTS_WITH_SEAT_BELT = 50;
    public static float POINTS_WITHOUT_SEAT_BELT = 1;
    public static float POINTS_CLOSED_SEMAPHORE = 100;
    public static float POINTS_ABOVE_SPEED = 10;
    public static float POINTS_RESPECT_SPEED = 10;
    public static float POINTS_SIDE_WALK = 10;
    public static float POINTS_CLICK_NOTIFICATION = 10;
    public static float POINTS_DRINK_ALCOOL = 100;
    public static float REMOVE_ALL_POINTS = 0;
    public static float POINTS_GAS_STATION = 10;
    public static float POINTS_AUTO_REPAIR = 10;
    public static float POINTS_RELAX = 10;

    //Life
    public static float START_LIFE = 10000;
    public static float LIFE_RECHARGE = 5;
    public static float MAX_LIFE = 50000;
    public static float LIFE_DRINK_ALCOOL = 500;

    public static float points;
    public static bool beltFastened;
    public static float life;

    public Slider sliderPoints;
    public Slider sliderLife;


    // Use this for initialization
    void Start() {
        points = START_POINTS;
        life = START_LIFE;
        beltFastened = false;
    }

    // Update is called once per frame
    void Update() {
        sliderPoints.value = points;
        sliderLife.value = life;       
    }

    public void FastenBelt() {
        if (!beltFastened) {
            beltFastened = true;
            MyNotifications.CallNotification(MyNotifications.SEAT_BELT_MESSAGE, 3);
            points += CNHManager.POINTS_WITH_SEAT_BELT;
            print("apertou cinto: " + CNHManager.points);
        }
    }
}
