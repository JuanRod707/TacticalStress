using Assets.Code.Cameras;
using Code.Acc;
using Code.Cameras;
using UnityEngine;

namespace Code.Directors
{
    public class ModeSwitcher : MonoBehaviour
    {
        public DualPointCamera Camera;
        public TacticalCameraCrane Crane;

        void Start()
        {
            SwitchToTacticalMode();
        }

        public void SwitchToTacticalMode()
        {
            Crane.enabled = true;
            Camera.SetCameraPoints(Crane.CameraPosition, Crane.Center);
        }

        public void SwitchToActionMode(TPSController soldier)
        {
            Crane.enabled = false;
            Camera.SetCameraPoints(soldier.ShoulderCamera, soldier.AimPoint);
        }
    }
}
