using UnityEngine;

namespace Code.BodyParts
{
    public class BodyPart : MonoBehaviour
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
    }
}
