using Code.Infrastructure.Repositories;
using Code.Interfaces;
using Code.UI;
using UnityEngine;

namespace Code.BodyParts
{
    public class BodyPart : MonoBehaviour, Damageable
    {
        public float HitPoints;
        public float DamageFactor;

        private float currentHitPoints;
        private CharacterJoint joint;
        private Body body;

        public bool IsDead
        {
            get { return currentHitPoints <= 0; }
        }

        void Start()
        {
            body = GetComponentInParent<Body>();
            joint = GetComponent<CharacterJoint>();
            currentHitPoints = HitPoints;
        }

        public void ReceiveDamage(float damage)
        {
            body.ReceiveDamage(damage * DamageFactor);
            currentHitPoints -= damage;
            DisplayDamage(damage * DamageFactor);

            if (IsDead)
            {
                KillBodyPart();    
            }
        }

        void KillBodyPart()
        {
            body.KillBody();
            Destroy(joint);
        }

        void DisplayDamage(float damage)
        {
            var number = Instantiate(Repos.ParticleRepo.DamageNumber, transform.position, Quaternion.identity).GetComponent<DynamicText>();
            number.SetDynamicText(damage.ToString("0.00"));
        }
    }
}
