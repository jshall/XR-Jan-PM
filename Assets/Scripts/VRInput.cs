using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public VRController LeftController;
    public VRController RightController;

    void Awake()
    {
        foreach (var controller in GetComponentsInChildren<VRController>())
        {
            controller.VRInput = this;
            if (controller.isLeftHand)
                LeftController = controller;
            else
                RightController = controller;
        }
    }
}
