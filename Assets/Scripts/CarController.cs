using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Wheel[] wheels;

    [Header("Car Specs")]
    public bool fourByFour = false;
    public bool tank = false;
    public float wheelBase;
    public float rearTrack;
    public float turnRadius;

    //[Header("Inputs")]
    private float steerInput;
    private float ackermannAngleLeft;
    private float ackermannAngleRight;

    // Update is called once per frame
    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");

        if(steerInput > 0) //turning right
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        } else if(steerInput < 0) // turning left
        {
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }
        else
        {
            ackermannAngleLeft = 0;
            ackermannAngleRight = 0;
        }
        foreach (Wheel w in wheels)
        {
            if (w.wheelFrontLeft)
                w.steerAngle = ackermannAngleLeft;
            if (w.wheelFrontRight)
                w.steerAngle = ackermannAngleRight;
            if (fourByFour)
            {
                if (tank)
                {
                    if (w.wheelBackLeft)
                        w.steerAngle = -ackermannAngleLeft;
                    if (w.wheelBackRight)
                        w.steerAngle = -ackermannAngleRight;
                }
                else
                {
                    if (w.wheelBackLeft)
                        w.steerAngle = ackermannAngleLeft;
                    if (w.wheelBackRight)
                        w.steerAngle = ackermannAngleRight;
                }
            }
        }
    }
}
