using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject ObjectToInstantiate;
    public static List<GameObject> ObjectsCreated;

    private List<ARRaycastHit> hits;
    private ARRaycastManager raycastManager;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = GetTouch();
        if (position == default || !raycastManager.Raycast(position, hits, TrackableType.PlaneWithinPolygon))
            return;

        var pose = hits[0].pose;
        ObjectsCreated.Add(Instantiate(ObjectToInstantiate, pose.position, pose.rotation));
    }

    Vector2 GetTouch()
    {
        return Input.touchCount == 0
            ? default
            : Input.GetTouch(0).position;
    }
}
