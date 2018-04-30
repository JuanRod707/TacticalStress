using UnityEngine;

namespace Code.BodyParts
{
    public class WeaponPivot : MonoBehaviour, ScriptableMotion
    {
        public Transform Target;

        void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Target != null)
            {
                this.transform.LookAt(Target);
            }

            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}
