using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator Anim;
    private VRInput controller;

    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        controller = GetComponentInChildren<VRInput>();
    }

    void Update()
    {
        if (controller && Anim)
            Anim.Play("FistClosing", 0, controller.gripValue);
    }
}
