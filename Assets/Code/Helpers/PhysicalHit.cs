using UnityEngine;

namespace Assets.Code.Helpers
{
    public class PhysicalHit
    {
        public bool DidHit { get; private set; }
        public RaycastHit HitInfo { get; private set; }

        public PhysicalHit(bool success, RaycastHit hit)
        {
            DidHit = success;
            HitInfo = hit;
        }
    }
}
