using System.Linq;
using Code.BodyParts;
using Code.Weapons.Munitions;
using UnityEngine;

namespace Assets.Code.Weapons.Munitions
{ 
    public class Grenade : MonoBehaviour
    {
        public GameObject ExplosionPrefab;
        public GameObject ExplosionDamageEffect;
        public float Range;
        public float Damage;
        public float PushForce;
        public int FragmentCount;

        public void Launch(float launchForce)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Fragment();
            Destroy(gameObject);
        }

        void Fragment()
        {
            var damageEffect = Instantiate(ExplosionDamageEffect, transform.position, Quaternion.identity)
                .GetComponent<ExplosionDamage>();
            damageEffect.Initialize(Damage, PushForce, Range);
        }
    }
}
