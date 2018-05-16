using UnityEngine;

namespace Assets.Code.Helpers
{
    public static class TransformHelper
    {
        public static void NormalizeRotationXZ(Transform target)
        {
            var rotation = target.eulerAngles;
            rotation.x = rotation.z = 0f;

            target.eulerAngles = rotation;
        }

        public static void NormalizeRotationZ(Transform target)
        {
            var rotation = target.eulerAngles;
            rotation.z = 0f;

            target.eulerAngles = rotation;
        }
    }
}
