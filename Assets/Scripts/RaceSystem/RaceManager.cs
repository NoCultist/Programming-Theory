using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RaceSystem
{
    public class RaceManager : MonoBehaviour
    {
        public class Race
        {
            public int NumberOfLaps = 1;
            public int NumberOfRacers = 2;
        }

        public Race raceSettings;
        private Checkpoint[] checkpoints;
        public Checkpoint[] Checkpoints { get { return checkpoints; } }

        private void Start()
        {
            InitializeCheckpoints();

        }

        //=============
        void InitializeCheckpoints()
        {
            List<Checkpoint> allCheckpoints = GameObject.FindObjectsOfType<Checkpoint>().ToList();
            allCheckpoints.Sort(CompareCheckpoints);
            checkpoints = allCheckpoints.ToArray();
        }

        int CompareCheckpoints(Checkpoint x, Checkpoint y)
        {
            if (x.index < y.index)
                return -1;
            if (x.index > y.index)
                return 1;
            return 0;
        }
        //==============

        // Singleton
        private static RaceManager _instance;
        public static RaceManager Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
                Destroy(gameObject);
        }
        // End of Singleton
    }
}