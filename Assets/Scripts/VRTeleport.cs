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
        if (!rig) rig = transform.parent;
        laser = GetComponent<LineRenderer>();
        controller = GetComponent<VRController>();
    }

    void Update()
    {
        if (controller.pressingPrimary || (!controller.isLeftHand && Input.GetKey(KeyCode.T)))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                destination = hit.point;
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, hit.point);
                shouldTeleport = laser.enabled = true;
            }
            else shouldTeleport = laser.enabled = false;
        }
        else if (shouldTeleport && (controller.GetButtonUp(VRButton.primaryClick) || (!controller.isLeftHand && Input.GetKeyUp(KeyCode.T))))
        {
            if (Physics.Raycast(rig.position, Vector3.down, out var hit))
                rig.position = destination + Vector3.up * hit.distance;
            shouldTeleport = laser.enabled = false;
        }
    }
}
