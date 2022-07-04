using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCarController : CarController
{
    [SerializeField] private AiModel _aiModel;
    [SerializeField] private Transform _target;
    
    private enum AiModel
    {
        Agressive,
        Racer
    }

    private void SetTarget()
    {
        switch (_aiModel)
        {
            case AiModel.Agressive:
                //set target at closest car
                //_target = Vector3.zero;
                break;
            case AiModel.Racer:
                //Set target at next checkpoint
                //_target = new Vector3();
                break;
            default:
                _target = transform;
                Debug.LogError("Undefined AiModel behaviour!");
                break;
        }
    }

    public override void Move()
    {
        transform.LookAt(_target);
        if (isGrounded && rb.velocity.z < car.MaxForwardSpeed)
        {
            rb.AddForce(transform.forward * car.ForwardAcceleration, ForceMode.Acceleration); // Add Movement
        }
        else
            rb.AddForce(transform.up * -200f); // Add Gravity
    }
}
