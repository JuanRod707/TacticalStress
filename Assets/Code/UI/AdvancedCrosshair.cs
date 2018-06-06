using Code.Actors;
using Code.Weapons;
using UnityEngine;

namespace Code.UI
{
    public class AdvancedCrosshair : MonoBehaviour
    {
        public float MinDimension;
        public float MaxDimension;
        public float CrossGrowthFactor;

        private Actor actor;
        private RectTransform myRect;

        void Start()
        {
            myRect = GetComponent<RectTransform>();
        }

        void Update()
        {
            if (actor != null)
            {
                UpdateDimension(actor.Inaccuracy);
            }
        }

        public void UpdateDimension(float inaccuracy)
        {
            var dim = (-inaccuracy * CrossGrowthFactor) + MinDimension;

            myRect.sizeDelta = new Vector2(dim, dim);
        }

        public void AttachToActor(Actor actor)
        {
            this.actor = actor;
        }
    }
}
