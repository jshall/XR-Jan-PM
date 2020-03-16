using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private Animator Anim;
    private VRController controller;

    void Awake()
    {
        Anim = GetComponentInChildren<Animator>();
        controller = GetComponent<VRController>();
    }

    void Update()
    {
        if (controller && Anim)
            if (controller.gripValue > 0.01)
                Anim.Play("Fist Closing", 0, controller.gripValue);
            else
                Anim.Play("Idle");
    }
}
