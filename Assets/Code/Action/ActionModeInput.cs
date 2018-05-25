using UnityEngine;

namespace Code.Action
{
    public class ActionModeInput : MonoBehaviour
    {
        public float Sensitivity;
        public float VertSensitivity;
        public float MaxElevation;
        public float MinElevation;
        public Transform AimPoint;
        public Transform ControlledBody;
        public Transform ShoulderCamera;
        public ActionModeController ActionController;

        private Vector3 previousMousePos;

        void Update()
        {
            Look();
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
        
        void ReadActionInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActionController.AttackCommand();
            }
            else if(Input.GetMouseButtonDown(1))
            {
                ActionController.AimCommand();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                ActionController.ReloadCommand();
            }
            else if (Input.mouseScrollDelta.magnitude > 0 || Input.GetKeyDown(KeyCode.F))
            {
                ActionController.CycleFireCommand();
            }
        }

        public void Activate()
        {
            this.enabled = true;
        }

        public void Deactivate()
        {
            this.enabled = false;
        }
    }
}
