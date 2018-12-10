using UnityEngine.UI;
using UnityEngine;

public class CarManager : MonoBehaviour {
    //Fuel
    public static float MAX_FUEL = 10000;
    public static float FUEL_RECHARGE = 10;
    public static float FUEL_CONSUME = 500;

    //Mechanic
    public static float MAX_MECHANIC = 50000;
    public static float MECHANIC_RECHARGE = 10;
    public static float MECHANIC_OBSTACLE_COLLIDER = 500;
    public static float MECHANIC_HOLE_COLLIDER = 500;
    public static float MECHANIC_SIDE_WALK = 50;

    public static float fuel;
    public static float mechanic;
    public Slider sliderFuel;
    public Slider sliderMechanic;


    // Use this for initialization
    void Start () {
        fuel = MAX_FUEL;
        mechanic = MAX_MECHANIC;
	}
	
	// Update is called once per frame
	void Update () {
        sliderFuel.value = fuel;
        sliderMechanic.value = mechanic;
    }
}
