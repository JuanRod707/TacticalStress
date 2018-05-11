using UnityEngine;

namespace Code.Effects
{
    public class AutoDispose : MonoBehaviour
    {
        public float LifeTime;

        void Start()
        {
            Destroy(this.gameObject, LifeTime);
        }
    }
}
