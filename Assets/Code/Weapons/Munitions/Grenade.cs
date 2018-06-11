using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Weapons.Munitions
{ 
    public class Grenade : MonoBehaviour
    {
        Rigidbody myBody;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void Launch(float launchForce)
        {
            myBody.AddForce(transform.forward * launchForce);
        }
    }
}
