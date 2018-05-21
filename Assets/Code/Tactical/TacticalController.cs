using System.Collections.Generic;
using System.Linq;
using Code.Action;
using Code.Actors;
using Code.Infrastructure.Map;
using Code.Infrastructure.Pathfinding;
using Code.Tactical.VisualElements;
using UnityEngine;

namespace Code.Tactical
{
    public class TacticalController : MonoBehaviour
    {
        public float MoveSpeed;
        public float StopDistance;
        public Transform MoveBody;
        public LayerMask FloorLayer;
        public TPSController ManualControl;
        public GameObject Crosshair;
        public ActorStats Actor;
        public int MovementCost;

        private bool isMoving;
        private int targetIndex;
        private Transform targetLocation;
        private List<Transform> path;
        MovementLine destinationLine;
        MovementMarker destinationMarker;

        public bool ReadyToMove
        {
            get { return enabled & !isMoving; }
        }

        public NavNode GetCurrentNavNode
        {
            get
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, Vector3.down, out hit, 2, FloorLayer))
                {
                    return hit.collider.GetComponentInParent<Cell>().NavNode;
                }

                return null;
            }
        }

        public void SetPath(IEnumerable<Transform> path)
        {
            if (Actor.CommitTimeAction((path.Count() - 1) * MovementCost))
            {
                this.path = path.ToList();
                targetIndex = 0;
                targetLocation = path.First();
                isMoving = true;

                destinationLine.Show(path);
                destinationMarker.Show(path);
            }
        }

        public void Select(MovementLine line, MovementMarker marker)
        {
            destinationLine = line;
            destinationMarker = marker;
        }
        
        void CheckPointReached()
        {
            MoveBody.position = targetLocation.position;

            if (targetLocation == path.Last())
            {
                isMoving = false;
                HideVisualElements();
            }
            else
            {
                targetIndex++;
                targetLocation = path[targetIndex];
                destinationLine.Show(path.Where(x => path.IndexOf(x) >= targetIndex));
            }
        }

        void MoveToTarget()
        {
            MoveBody.LookAt(targetLocation);
            var normalizedRot = new Vector3(0f, MoveBody.eulerAngles.y, 0f);
            MoveBody.eulerAngles = normalizedRot;

            MoveBody.Translate(Vector3.forward * MoveSpeed);

            if (Vector3.Distance(MoveBody.position, targetLocation.position) < StopDistance)
            {
                CheckPointReached();
            }
        }

        void Update()
        {
            if (isMoving)
            {
                MoveToTarget();
            }
        }

        void Activate()
        {
            this.enabled = true;
            ManualControl.Deactivate();
            Crosshair.SetActive(false);
        }

        void Deactivate()
        {
            this.enabled = false;
            ManualControl.Activate();
            Crosshair.SetActive(true);
        }

        public void ChangeControlMode()
        {
            if (enabled)
            {
                Deactivate();
            }
            else
            {
                Activate();
            }
        }

        void HideVisualElements()
        {
            destinationMarker.Hide();
            destinationLine.Hide();
        }
    }
}
