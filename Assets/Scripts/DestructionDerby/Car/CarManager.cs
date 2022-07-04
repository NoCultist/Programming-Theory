using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private CarSystemSettings settings;
    public static CarSystemSettings Settings { get { return instance.settings; } }

    private CarController[] cars;
    private int playerCarIndex;


    private void Start()
    {
        cars = FindObjectsOfType<CarController>();
        if (cars.Length == 0)
        {
            Debug.LogError("No cars detected!");
        }
        else
        {
            playerCarIndex = GetPlayerCarIndex();
            Debug.Log("PlayerCarIndex:" + playerCarIndex);
        }
    }

    private int GetPlayerCarIndex() //returns -1 if no player
    {
        int index = -1;
        if (cars.Any(x => x.GetType() == typeof(PlayerCarController)))
        {
            index = cars.Select((item, index) => new
            {
                isPlayer = item.GetType() == typeof(PlayerCarController),
                Position = index
            }).Where(i => i.isPlayer == true)
                .First()
                .Position;
        }
        return index;
    }


    //Singleton
    private static CarManager instance;
    public static CarManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == this) return;
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    //End of Singleton
}
