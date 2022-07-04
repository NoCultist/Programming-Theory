using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : CarController
{
    private float moveInput;
    private float turnInput;

    public override void Move()
    {

        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        float newRot = turnInput * car.TurnSpeed * Time.deltaTime * moveInput;

        transform.position = rb.transform.position;
        moveInput *= moveInput > 0 ? car.ForwardAcceleration : car.BackwardAcceleration;

        if (isGrounded)
            transform.Rotate(0, newRot, 0, Space.World);


        if (isGrounded && rb.velocity.z < car.MaxForwardSpeed)
        {
            rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration); // Add Movement
        }
        else
            rb.AddForce(Vector3.up * -200f); // Add Gravity
    }

}
