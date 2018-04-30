using UnityEngine;

namespace Code.BodyParts
{
    public class TorsoRotator : MonoBehaviour, ScriptableMotion
    {
        public Transform WeaponPivot;
        public float RotateStrength;

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
            var pivotDirection = transform.InverseTransformDirection(WeaponPivot.forward);
            if (pivotDirection.x > 0.2f)
            {
                 myBody.AddTorque(Vector3.up * RotateStrength);   
            }
            else if (pivotDirection.x < 0.2f)
            {
                myBody.AddTorque(Vector3.up * -RotateStrength);
            }
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}
