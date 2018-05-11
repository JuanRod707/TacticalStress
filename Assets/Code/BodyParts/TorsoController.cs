using UnityEngine;

namespace Code.BodyParts
{
    public class TorsoController : MonoBehaviour
    {
        public Transform TargetView;

        void Update()
        {
            if (TargetView != null)
            {
                this.transform.LookAt(TargetView);
            }

            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }
    }
}
