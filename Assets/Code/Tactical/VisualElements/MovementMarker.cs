using System.Collections.Generic;
using System.Linq;
using Assets.Code.UI;
using UnityEngine;

namespace Code.Tactical.VisualElements
{
    public class MovementMarker : MonoBehaviour
    {
        public DynamicText MovementCost;

        public void Show(IEnumerable<Transform> path)
        {
            gameObject.SetActive(true);
            if (path == null)
                return;

            transform.position = path.Last().position;

            if (MovementCost != null)
            {
                MovementCost.SetDynamicText(path.Count() - 1);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
