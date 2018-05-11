using UnityEngine;

namespace Code.Acc
{
    public class AdvancedCrosshair : MonoBehaviour
    {
        public float MinDimension;
        public float MaxDimension;
        public float CrossGrowthFactor;

        private RectTransform myRect;

        void Start()
        {
            myRect = GetComponent<RectTransform>();
        }

        public void UpdateDimension(float inaccuracy)
        {
            var dim = (-inaccuracy * CrossGrowthFactor) + MinDimension;

            myRect.sizeDelta = new Vector2(dim, dim);
        }
    }
}
