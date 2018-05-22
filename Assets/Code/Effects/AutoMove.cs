using UnityEngine;

namespace Code.Effects
{
    public class AutoMove : MonoBehaviour
    {
        public Vector3 Axis;
        public float Speed;

        void Update()
        {
            transform.Translate(Axis * Speed);
        }
    }
}
