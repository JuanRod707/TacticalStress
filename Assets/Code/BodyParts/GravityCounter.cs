using UnityEngine;

namespace Code.BodyParts
{
    public class GravityCounter : MonoBehaviour, ScriptableMotion
    {
        public float counterForce;

        private Rigidbody myBody;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            myBody.AddForce(Vector3.up * myBody.mass * counterForce);
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}