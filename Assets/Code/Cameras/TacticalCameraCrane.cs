using UnityEngine;

namespace Code.Cameras
{
    public class TacticalCameraCrane : MonoBehaviour
    {
        public Transform Center;
        public Transform CameraPosition;

        public float RotationSpeed;
        public float MovementSpeed;

        void Update()
        {
            Move();
            Rotate();
        }

        void Move()
        {
            var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            Center.Translate(moveVector * MovementSpeed);
        }

        void Rotate()
        {
            if (Input.GetKey(KeyCode.E))
            {
                Center.Rotate(Vector3.up * RotationSpeed);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Center.Rotate(Vector3.up * -RotationSpeed);
            }
        }
    }
}
