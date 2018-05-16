using UnityEngine;

namespace Assets.Code.Sandbox
{
    public class ForceMove : MonoBehaviour
    {
        public Vector3 ForceDirection;
        public float PushStrength;
	
        void Start ()
        {
            GetComponent<Rigidbody>().AddForce(ForceDirection * PushStrength);
        }
    }
}
