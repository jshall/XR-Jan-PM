using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTeleport : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport")]
    public Transform simHand;
    private LineRenderer laser;
    private Vector3 hitPosition;
    private bool shouldTeleport;
    void Awake()
    {
        laser = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            RaycastHit hit;
            if (Physics.Raycast(simHand.position, simHand.forward, out hit))
            {
                hitPosition = hit.point;
                laser.SetPosition(0, simHand.position);
                laser.SetPosition(1, hitPosition);
                laser.enabled = true;
                shouldTeleport = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
                simHand.position = hitPosition;
                shouldTeleport = false;
                laser.enabled = false;
        }
    }
}
