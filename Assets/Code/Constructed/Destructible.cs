using Code.Interfaces;
using UnityEngine;

namespace Code.Constructed
{
    public class Destructible : MonoBehaviour, Damageable
    {
        public float StartingHp;
        public GameObject BrokenPrefab;
        
        float currentHp;
        private bool destroyed;
        
        void Start()
        {
            currentHp = StartingHp;
        }
        
        public void ReceiveDamage(float damage)
        {
            currentHp -= damage;
            if (currentHp <= 0f && !destroyed)
            {
                Instantiate(BrokenPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
                destroyed = true;
            }
        }
    }
}