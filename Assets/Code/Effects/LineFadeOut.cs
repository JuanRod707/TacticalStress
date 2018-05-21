using UnityEngine;

namespace Code.Effects
{
    public class LineFadeOut : MonoBehaviour
    {
        public float LifeTime;

        private float alphaAmount;
        private float alphaDecay;
        private LineRenderer renderer;

        void Start()
        {
            alphaAmount = 1f;
            alphaDecay = 1f / LifeTime;
            renderer = GetComponent<LineRenderer>();
            Destroy(this.gameObject, LifeTime);
        }

        void Update()
        {
            alphaAmount -= Time.deltaTime * alphaDecay;

            var alpha = new [] { new GradientAlphaKey(alphaAmount, 0.5f) };
            renderer.colorGradient.alphaKeys = alpha;
        }
    }
}
