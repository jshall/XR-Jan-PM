using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    public Transform rig;

    private LineRenderer laser;
    private VRController controller;
    private Vector3 destination;
    private bool shouldTeleport;

    void Awake()
    {
        laser = GetComponent<LineRenderer>();
        controller = GetComponent<VRController>();
    }

    void Update()
    {
        if (controller.GetButton(VRButton.primaryClick))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                destination = hit.point;
                laser.SetPosition(1, destination);
                shouldTeleport = laser.enabled = true;
            }
            else shouldTeleport = laser.enabled = false;
        }
        else if (shouldTeleport && controller.GetButtonUp(VRButton.primaryClick))
        {
            if (Physics.Raycast(rig.position, Vector3.down, out var hit))
                rig.position = destination + Vector3.up * hit.distance;
            shouldTeleport = laser.enabled = false;
        }
    }
}
