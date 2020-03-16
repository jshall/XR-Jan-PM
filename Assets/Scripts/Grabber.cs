using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public List<GameObject> touching = new List<GameObject>();
    public List<GameObject> holding = new List<GameObject>();

    private VRController controller;
    private FixedJoint joint;

    void Awake()
    {
        if (TryGetComponent(typeof(FixedJoint), out var c))
            joint = (FixedJoint)c;
        controller = GetComponent<VRController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other is TerrainCollider)
            return;
        if (Select(other) is GameObject obj)
            touching.Add(obj);
    }

    void OnTriggerExit(Collider other)
    {
        if (Select(other) is GameObject obj)
            touching.Remove(obj);
    }

    void Update()
    {
        if (joint)
        {
            if (touching.Any())
                GrabWithJoint();
        }
        else
        {
            if (controller.gripValue >= 0.8 && touching.Except(holding).Any())
                GrabWithParenting();
            else if (controller.gripValue < 0.8 && holding.Any())
                ReleaseWithParenting();
        }
    }

    private GameObject Select(Collider collider)
        => collider.attachedRigidbody?.gameObject;

    private void GrabWithParenting()
    {
        foreach (var obj in touching)
        {
            holding.Add(obj);
            obj.transform.SetParent(this.transform);
            if (obj.GetComponent<Rigidbody>() is Rigidbody r)
            {
                r.useGravity = false;
                r.isKinematic = true;
            }
        }
    }

    private void ReleaseWithParenting()
    {
        foreach (var obj in holding)
        {
            if (obj.transform.parent != this.transform)
                continue;
            obj.transform.SetParent(null);
            if (obj.GetComponent<Rigidbody>() is Rigidbody r)
            {
                r.useGravity = true;
                r.isKinematic = false;
                r.velocity = controller.velocity;
            }
        }
        holding.Clear();
    }

    private void GrabWithJoint()
    {
        foreach (var obj in touching)
        {
            var body = obj.GetComponent<Rigidbody>();
            if (joint.connectedBody == null)
                joint.connectedBody = body;
            if (joint.connectedBody == body)
                joint.breakForce = joint.breakTorque = controller.gripValue * controller.gripForce;
        }
    }
}