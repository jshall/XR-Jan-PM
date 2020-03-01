using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayable : MonoBehaviour
{
    void Start()
    {
        if (GetComponent<Renderer>() is Renderer renderer)
            renderer.material.renderQueue = 3002;
    }
}
