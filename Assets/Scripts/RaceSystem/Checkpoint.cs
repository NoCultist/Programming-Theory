using UnityEngine;

namespace RaceSystem
{
    public class Checkpoint : MonoBehaviour
    {
        public int index;

        private void OnTriggerEnter(Collider other)
        {
            var racer = other.GetComponent<Racer>();
            if (racer != null)
            {
                if (racer.LastCheckpoint == index - 1)
                {
                    racer.LastCheckpoint = index;
                }
                else if (racer.LastCheckpoint == RaceManager.Instance.Checkpoints.Length - 1 && index == 0)
                {
                    racer.LastCheckpoint = 0;
                    racer.Lap += 1;
                }
            }
        }
    }
}