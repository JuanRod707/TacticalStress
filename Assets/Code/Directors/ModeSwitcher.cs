using Code.Action;
using Code.Cameras;
using Code.UI.Action;
using UnityEngine;

namespace Code.Directors
{
    public class ModeSwitcher : MonoBehaviour
    {
        public DualPointCamera Camera;
        public TacticalCameraCrane Crane;
        public AttackPanel ActionModeUI;
        public GameObject TacticalModeUI;

        void Start()
        {
            SwitchToTacticalMode();
        }

        public void SwitchToTacticalMode()
        {
            Crane.enabled = true;
            Camera.SetCameraPoints(Crane.CameraPosition, Crane.Center);

            ActionModeUI.gameObject.SetActive(false);
            TacticalModeUI.gameObject.SetActive(true);
        }

        public void SwitchToActionMode(ActionModeInput soldier)
        {
            Crane.enabled = false;
            Camera.SetCameraPoints(soldier.ShoulderCamera, soldier.AimPoint);

            ActionModeUI.gameObject.SetActive(true);
            TacticalModeUI.gameObject.SetActive(false);
        }
    }
}
