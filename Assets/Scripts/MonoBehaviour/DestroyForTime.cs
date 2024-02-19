using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour
{
    public float time = 1;

    private void Start()
    {
        Invoke("Destroy", time);
    }

    private void Destroy()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}

