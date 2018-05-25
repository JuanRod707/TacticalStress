using Code.Enums;
using UnityEngine;

namespace Code.Cameras
{
    public class CameraZoom : MonoBehaviour
    {
        public float ZoomSpeed;

        private float initialFov;
        private Camera cam;
        private float zoomTarget;
        private CameraZoomState state;

        public void ZoomIn(float fovModifier)
        {
            zoomTarget = initialFov - fovModifier;
            state = CameraZoomState.ZoomIn;
        }

        public void ZoomOut()
        {
            state = CameraZoomState.ZoomOut;
        }

        void Start()
        {
            cam = GetComponent<Camera>();
            initialFov = cam.fieldOfView;
        }

        void Update()
        {
            if (state == CameraZoomState.ZoomIn)
            {
                ZoomingIn();
            }
            else if (state == CameraZoomState.ZoomOut)
            {
                ZoomingOut();
            }
        }

        void ZoomingIn()
        {
            if (cam.fieldOfView > zoomTarget)
            {
                cam.fieldOfView -= ZoomSpeed;
            }
            else
            {
                state = CameraZoomState.Static;
            }
        }

        void ZoomingOut()
        {
            if (cam.fieldOfView < initialFov)
            {
                cam.fieldOfView += ZoomSpeed;
            }
            else
            {
                state = CameraZoomState.Static;
            }
        }
    }
}
