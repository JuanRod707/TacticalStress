
using System.Collections.Generic;
using System.Linq;
using Code.Map;
using UnityEngine;

namespace Code.Tactical
{
    public class TacticalController : MonoBehaviour
    {
        public float MoveSpeed;
        public float StopDistance;
        public Transform MoveBody;
        public LayerMask FloorLayer;
        
        private bool isMoving;
        private int targetIndex;
        private Transform targetLocation;
        private List<Transform> path;

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
            this.path = path.ToList();
            targetIndex = 0;
            targetLocation = path.First();
            isMoving = true;
        }

        void CheckPointReached()
        {
            MoveBody.position = targetLocation.position;

            if (targetLocation == path.Last())
            {
                isMoving = false;
            }
            else
            {
                targetIndex++;
                targetLocation = path[targetIndex];
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
    }
}
