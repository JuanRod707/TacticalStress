using Code.Weapons;
using UnityEngine;

namespace Code.Action
{
    public class TPSController : MonoBehaviour
    {
        public float Speed;
        public float Sensitivity;
        public float VertSensitivity;
        public Rifle Weapon;
        public float MaxElevation;
        public float MinElevation;
        public Transform AimPoint;
        public Transform ControlledBody;
        public Transform ShoulderCamera;

        private Vector3 previousMousePos;

        void Update()
        {
            Look();
            //Move();
            ReadActionInput();
        }

        void Look()
        {
            var mouse = Input.mousePosition;
            var mouseDelta = mouse - previousMousePos;

            ControlledBody.Rotate(Vector3.up * mouseDelta.x * Sensitivity);
            AimPoint.Translate(new Vector3(0f, mouseDelta.y * VertSensitivity, 0f));

            var elevation = AimPoint.localPosition;
            if (elevation.y < MinElevation)
            {
                elevation.y = MinElevation;
                AimPoint.localPosition = elevation;
            }
            else if (elevation.y > MaxElevation)
            {
                elevation.y = MaxElevation;
                AimPoint.localPosition = elevation;
            }

            previousMousePos = mouse;
        }

        void Move()
        {
            var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            ControlledBody.Translate(moveVector * Speed);
        }

        void ReadActionInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
            else if(Input.GetMouseButtonDown(1))
            {
                Aim();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
            else if (Input.mouseScrollDelta.magnitude > 0)
            {
                ChangeFireMode();
            }
        }

        void Attack()
        {
            Weapon.Shoot();
        }

        void ChangeFireMode()
        {
            
        }

        void Reload()
        {
            
        }

        void Aim()
        {
            
        }

        public void Activate()
        {
            this.enabled = true;
            Weapon.enabled = true;
        }

        public void Deactivate()
        {
            this.enabled = false;
            Weapon.enabled = false;
        }
    }
}
