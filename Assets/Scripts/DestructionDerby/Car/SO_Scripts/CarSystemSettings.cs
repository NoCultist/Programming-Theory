using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CarSystemSettings")]
[System.Serializable]
public class CarSystemSettings : ScriptableObject
{
    public LayerMask groundLayer;
}
