using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    [Header("Plane State")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum  engine thrust when at 100% throttle")]
    public float maxThrust = 200f;

    [Tooltip("This is how responsive the plane is when it's rolling/pitching/yawing")]
    public float responsivesness = 10f;

    private float throttle; // percentage of maximum engine
    private float roll; // tilt left and right
    private float pitch; // tilting front and back
    private float yaw; // turns left and right

    public float lift = 135f;


    private float responseModifier
    {
        get { return (rb.mass / 10f) * responsivesness; }
  
    }

    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        // set rotational values for inputs

        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        // throttle
        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);



    }


    private void Update()
    {
        HandleInputs();
        UpdateHUD();

    }

    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward * maxThrust * throttle);
        //rb.AddTorque(transform.up * yaw * responseModifier);
        //rb.AddTorque(transform.right * pitch * responseModifier);
        //rb.AddTorque(-transform.forward * roll * responseModifier);

        //rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);


    }

    private void UpdateHUD()
    {
        hud.text = "Throttle " + throttle.ToString("F0")+ "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + " m";
    }
}