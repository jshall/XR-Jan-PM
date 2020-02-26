using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public KeyCode GrabKey = KeyCode.Mouse0;
    public List<GameObject> touching = new List<GameObject>();
    public List<GameObject> holding = new List<GameObject>();

    private Vector3 lastPosition;
    private Vector3 velocity;

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
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        if (Input.GetKeyDown(GrabKey))
            Grab();
        if (Input.GetKeyUp(GrabKey))
            Release();
    }

    private GameObject Select(Collider collider)
        => collider.attachedRigidbody?.gameObject;

    private void Grab()
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

    private void Release()
    {
        foreach (var obj in holding)
        {
            obj.transform.SetParent(null);
            if (obj.GetComponent<Rigidbody>() is Rigidbody r)
            {
                r.useGravity = true;
                r.isKinematic = false;
                r.velocity = velocity;
            }
        }
        holding.Clear();
    }
}
