using Code.Interfaces;
using UnityEngine;

namespace Code.Constructed
{
    public class Destructible : MonoBehaviour, Damageable
    {
        public float StartingHp;
        public GameObject BrokenPrefab;
        
        public float currentHp;
        
        void Start()
        {
            currentHp = StartingHp;
        }
        
        public void ReceiveDamage(float damage)
        {
            currentHp -= damage;
            if (currentHp <= 0f)
            {
                Instantiate(BrokenPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}