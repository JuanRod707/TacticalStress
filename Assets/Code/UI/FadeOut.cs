using UnityEngine;

namespace Code.Effects
{
    public class FadeOut : MonoBehaviour
    {
        public float LifeTime;
        public CanvasGroup Canvas;

        private float alphaAmount;
        private float alphaDecay;
        
        void Start()
        {
            alphaAmount = 1f;
            alphaDecay = 1f / LifeTime;
            Destroy(this.gameObject, LifeTime);
        }

        void Update()
        {
            alphaAmount -= Time.deltaTime * alphaDecay;
            Canvas.alpha = alphaAmount;
        }
    }
}
