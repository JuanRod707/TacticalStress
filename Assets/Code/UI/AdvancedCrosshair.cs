using Code.Weapons;
using UnityEngine;

namespace Code.UI
{
    public class AdvancedCrosshair : MonoBehaviour
    {
        public float MinDimension;
        public float MaxDimension;
        public float CrossGrowthFactor;

        private Weapon attachedWeapon;
        private RectTransform myRect;

        void Start()
        {
            myRect = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (attachedWeapon != null)
            {
                UpdateDimension(attachedWeapon.Inaccuracy);
            }
        }

        public void UpdateDimension(float inaccuracy)
        {
            var dim = (-inaccuracy * CrossGrowthFactor) + MinDimension;

            myRect.sizeDelta = new Vector2(dim, dim);
        }

        public void AttachWeapon(Weapon weapon)
        {
            attachedWeapon = weapon;
        }
    }
}
