using Assets.Code.Interfaces;
using UnityEngine;

namespace Assets.Code.Constructed
{
    public class Debris : MonoBehaviour, TimedEvent
    {
        public int TurnsToExpire;
        private int turnsElapsed;

        void Start()
        {
            turnsElapsed = 0;
            transform.SetParent(GameObject.Find("Debris").transform);
        }

        public void OnTurnEnded()
        {
            turnsElapsed++;
            if (turnsElapsed > TurnsToExpire)
            {
                Expire();
            }
        }

        void Expire()
        {
            Destroy(gameObject);
        }
    }
}
