using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Tactical.VisualElements
{
    public class MovementLine : MonoBehaviour
    {
        public LineRenderer Renderer;
        public float MovementLineOffset;

        public void Show(IEnumerable<Transform> path)
        {
            gameObject.SetActive(true);
            if (path == null)
                return;

            Renderer.positionCount = path.Count();

            for (int i = 0; i < path.Count(); i++)
            {
                var renderPosition = path.ToArray()[i].position;
                renderPosition.y += MovementLineOffset;
                Renderer.SetPosition(i, renderPosition);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
