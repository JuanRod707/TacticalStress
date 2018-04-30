using UnityEngine;

namespace Code.BodyParts
{
    public class Pushable :MonoBehaviour
    {
        private Rigidbody myBody;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void Push(Vector3 fromPoint, float strength)
        {
            var distance = Vector3.Distance(transform.position, fromPoint);
            var pushVector = transform.InverseTransformPoint(fromPoint).normalized;

            pushVector *= -strength / distance;

            myBody.AddForce(pushVector);
        }
    }
}
