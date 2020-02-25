using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public KeyCode GrabKey = KeyCode.Mouse0;
    public List<GameObject> touching = new List<GameObject>();
    public List<GameObject> holding = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other is TerrainCollider)
            return;
        touching.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        touching.Remove(other.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(GrabKey))
            Grab();
        if (Input.GetKeyUp(GrabKey))
            Release();
    }

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
            }
        }
        holding.Clear();
    }
}
