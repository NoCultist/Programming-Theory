using System;

using UnityEngine;

namespace RaceSystem
{
    public class Racer : MonoBehaviour
    {
        public int LastCheckpoint;
        public int Lap;
        public TimeSpan[] TimesPerLoop;

        public Racer(int NumberOfLaps)
        {
            LastCheckpoint = 0;
            Lap = 0;
            TimesPerLoop = new TimeSpan[NumberOfLaps];
        }
    }
}