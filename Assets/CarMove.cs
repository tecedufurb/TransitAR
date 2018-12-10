using UnityEngine;

public class CarMove : MonoBehaviour {

    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public float m_PitchRange = 0.2f;
    public Joystick joystick;

    public static float movementValue = 0;
    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    public static float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;


    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable() {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable() {
        m_Rigidbody.isKinematic = true;
    }

    private void Start() {
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
    }
    
    private void Update() {
        // Store the player's input and make sure the audio for the engine is playing.        
        m_MovementInputValue = (-1 * (joystick.Vertical /2)) + Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = (joystick.Horizontal /2) + Input.GetAxis(m_TurnAxisName);

        if (GameManager.alcool) {
            m_MovementInputValue *= 5;
            m_TurnInputValue *= 5;
        }
    }

    private void FixedUpdate() {
        // Move and turn the tank.
        Move();
        Turn();
    }
    
    private void Move() {
        // Adjust the position of the tank based on the player's input.        
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        if(m_MovementInputValue != 0) {
            if (CNHManager.beltFastened) {
                movementValue = m_MovementInputValue > 0 ? m_MovementInputValue : (m_MovementInputValue * -1);
                CarManager.fuel -= movementValue;

                m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
            } else {
                CNHManager.points -= CNHManager.POINTS_WITHOUT_SEAT_BELT;
                print("sem cinto: " + CNHManager.points);
                //CNHManager.beltFastened = true;
            }
        }      
    }

    private void Turn() {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        if (CNHManager.beltFastened)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }
    }
}
