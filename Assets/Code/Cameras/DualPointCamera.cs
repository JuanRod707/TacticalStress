using UnityEngine;

namespace Assets.Code.Cameras
{
    public class DualPointCamera : MonoBehaviour
    {
        public float Elasticity;

        Transform targetView;
        Transform targetPos;
        
        void FixedUpdate()
        {
            if (targetPos != null)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos.position, Elasticity);
            }

            if (targetView != null)
            {
                transform.LookAt(targetView);
            }

            var eul = transform.eulerAngles;
            eul.z = 0f;
            transform.eulerAngles = eul;
        }

        public void SetCameraPoints(Transform position, Transform targetView)
        {
            this.targetView = targetView;
            targetPos = position;
        }
    }
}
