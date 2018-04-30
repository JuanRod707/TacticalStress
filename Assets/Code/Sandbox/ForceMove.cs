using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMove : MonoBehaviour
{
    public Vector3 ForceDirection;
    public float PushStrength;
	
	void Start ()
    {
		GetComponent<Rigidbody>().AddForce(ForceDirection * PushStrength);
	}
}
