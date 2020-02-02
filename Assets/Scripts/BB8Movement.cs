using System;
using System.Linq;
using UnityEngine;

public class BB8Movement: MonoBehaviour
{
    public float RotationSpeed = 8;
    public KeyCode Dash = KeyCode.LeftShift;
    public float DashMultiplier = 3;
    public GameObject Head;

    private Camera Camera;
    private Rigidbody Body;
    private float origAngularDrag;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Body = GetComponent<Rigidbody>();
        origAngularDrag = Body.angularDrag;
        Camera = Head.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame1
    void Update()
    {
        // Toggle brake
        if (Input.GetKeyDown(KeyCode.Space))
            Body.angularDrag = float.IsPositiveInfinity(Body.angularDrag)
                ? origAngularDrag
                : float.PositiveInfinity;

        // Toggle light
        if (Input.GetKeyDown(KeyCode.CapsLock))
            foreach (var l in GetComponentsInChildren<Light>())
                l.enabled = !l.enabled;

        // Move head and camera
        Head.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        if (Camera != null)
        {
            Camera.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
            Camera.transform.Translate(0, 0, Input.mouseScrollDelta.y);
        }

        // Move roller
        var input = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        input *= Time.deltaTime * RotationSpeed * (Input.GetKey(Dash) ? DashMultiplier : 1);
        input = Head.transform.rotation * input;
        Body.AddTorque(input, ForceMode.Impulse);
    }

}
