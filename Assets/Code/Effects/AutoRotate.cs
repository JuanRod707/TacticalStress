using UnityEngine;

namespace Assets.Code.Effects
{
    public class AutoRotate : MonoBehaviour
    {
        public Vector3 Axis;
        public float Speed;

        void Update()
        {
            transform.Rotate(Axis * Speed);
        }
    }
}
