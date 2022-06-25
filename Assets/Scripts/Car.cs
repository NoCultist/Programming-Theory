using UnityEngine;

[CreateAssetMenu(menuName = "Car")]
[System.Serializable]
public class Car : ScriptableObject
{
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float forwardAcceleration;
    public float backwardAcceleration;
    public float turnSpeed;
}