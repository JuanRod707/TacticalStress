using Code.BodyParts;
using UnityEngine;

namespace Code.Weapons.Munitions
{
    public class ExplosionDamage : MonoBehaviour
    {
        public float EffectDuration;

        private float damage;
        private float pushForce;
        
        public void Initialize(float damage, float pushForce, float radius)
        {
            this.damage = damage;
            this.pushForce = pushForce;
            GetComponent<SphereCollider>().radius = radius;
            
            Destroy(gameObject, EffectDuration);
        }
        
        private void OnTriggerStay(Collider other)
        {
            var bodyPart = other.GetComponent<BodyPart>();
            if (bodyPart != null)
            {
                bodyPart.ReceiveDamage(damage);
            }

            var pushable = other.GetComponent<Pushable>();
            if (pushable != null)
            {
                pushable.Push(transform.position, pushForce);
            }
        }
    }
}