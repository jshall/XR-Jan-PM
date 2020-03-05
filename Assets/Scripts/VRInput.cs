using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;
    public float gripValue;
    public float triggerValue;
    public Vector3 velocity;
    public float maxForce = 100;

    private string gripAxis;
    private string triggerAxis;
    private Vector3 lastPosition;

    void Awake()
    {
        if (isLeftHand)
        {
            gripAxis = "Left Grip";
            triggerAxis = "Left Trigger";
        }
        else
        {
            gripAxis = "Right Grip";
            triggerAxis = "Right Trigger";
        }
    }

    // Update is called once per frame
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        gripValue = Input.GetAxis(triggerAxis);
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
