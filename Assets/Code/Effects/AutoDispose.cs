using UnityEngine;

namespace Assets.Code.Effects
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
