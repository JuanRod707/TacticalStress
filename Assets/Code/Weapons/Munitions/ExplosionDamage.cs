using Code.BodyParts;
using Code.Interfaces;
using UnityEngine;

namespace Code.Weapons.Munitions
{
    public class ExplosionDamage : MonoBehaviour
    {
        public float EffectDuration;
        public float DistanceFactor;

        private float damage;
        private float pushForce;
        
        public void Initialize(float damage, float pushForce, float radius)
        {
            this.damage = damage;
            this.pushForce = pushForce;
            GetComponent<SphereCollider>().radius = radius;
            
            Destroy(gameObject, EffectDuration);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var distance = Vector3.Distance(transform.position, other.transform.position);

            if (IsInLineOfSight(other.transform, other, distance))
            {
                var damageable = other.transform.parent.GetComponent<Damageable>();
                if (damageable != null)
                {
                    damageable.ReceiveDamage(damage / (distance * DistanceFactor));
                }

                var pushable = other.transform.parent.GetComponent<Pushable>();
                if (pushable != null)
                {
                    pushable.Push(transform.position, pushForce / (distance * DistanceFactor));
                }
            }
        }

        bool IsInLineOfSight(Transform target, Collider targetCollider, float distance)
        {
//            RaycastHit hit;
//            var ray = new Ray(transform.position, target.position);
//            if (Physics.Raycast(ray, out hit, distance))
//            {
//                if (!hit.collider.Equals(targetCollider))
//                {
//                    return false;
//                }
//            }

            return true;
        }
    }
}