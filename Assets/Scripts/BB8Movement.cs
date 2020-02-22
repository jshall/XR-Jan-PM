using System.Linq;
using UnityEngine;

public class BB8Movement : MonoBehaviour
{
    public float RotationSpeed = 20;
    public float DashMultiplier = 5;
    public float JumpForce = 20;
    public GameObject Head;

    private Camera Camera;
    private Rigidbody Body;
    private float origAngularDrag;

    public KeyCode DashKey = KeyCode.LeftShift;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode BrakeKey = KeyCode.R;
    public KeyCode LightKey = KeyCode.F;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Body = GetComponent<Rigidbody>();
        origAngularDrag = Body.angularDrag;
        Camera = Head.GetComponentInChildren<Camera>();

        Body.maxAngularVelocity = float.PositiveInfinity;
        Player.Reset();
    }

    void Update()
    {
        // Toggle brake
        if (Input.GetKeyDown(BrakeKey))
            Body.angularDrag = float.IsPositiveInfinity(Body.angularDrag)
                ? origAngularDrag
                : float.PositiveInfinity;

        // Toggle light
        if (Input.GetKeyDown(LightKey))
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
        input *= RotationSpeed * (Input.GetKey(DashKey) ? DashMultiplier : 1) * Time.deltaTime;
        input = Head.transform.rotation * input;
        Body.AddTorque(input, ForceMode.Impulse);
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(JumpKey) && collision.collider is TerrainCollider)
                Body.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
}
