using UnityEngine;

namespace Assets.Code.BodyParts
{
    public class Grapple : MonoBehaviour, ScriptableMotion
    {
        public Transform Target;
        public float GrabSpeed;

        private Rigidbody mybody;

        void Start()
        {
            mybody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Target != null)
            {
                Move();
            }
        }

        public void Move()
        {
            mybody.AddForce((Target.position - transform.position) * GrabSpeed);
            //transform.position = Vector3.Lerp(transform.position, Target.position, GrabSpeed);
            transform.rotation = Target.rotation;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}
