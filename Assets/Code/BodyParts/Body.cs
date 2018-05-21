using UnityEngine;

namespace Code.BodyParts
{
    public class Body : MonoBehaviour
    {
        public float HitPoints;
        public Rigidbody[] FeetAnchors;

        private float currentHitPoints;

        void Start()
        {
            currentHitPoints = HitPoints;
        }

        public void ReceiveDamage(float damage)
        {
            currentHitPoints -= damage;
            if (currentHitPoints <= 0)
            {
                KillBody();
            }
        }

        public void KillBody()
        {
            foreach (var feetAnchor in FeetAnchors)
            {
                feetAnchor.isKinematic = false;
            }

            foreach (var counter in GetComponentsInChildren<ScriptableMotion>())
            {
                counter.Disable();
            }
        }
    }
}
