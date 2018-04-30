using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDispose : MonoBehaviour
{
    public float LifeTime;

    void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }
}
