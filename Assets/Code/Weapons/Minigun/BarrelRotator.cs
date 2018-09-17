using UnityEngine;

namespace Code.Weapons.Minigun
{
    public class BarrelRotator : MonoBehaviour
    {
        public float Acceleration;
        public float Deceleration;
        public float MaxSpeed;

        public float currentSpeed;

        void Update()
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= Deceleration;
            }

            Rotate();
        }

        void Rotate()
        {
            this.transform.Rotate(0f, 0f, currentSpeed);
        }

        public void Accelerate()
        {
            if (currentSpeed < MaxSpeed)
            {
                currentSpeed += Acceleration;
            }
        }
    }
}
