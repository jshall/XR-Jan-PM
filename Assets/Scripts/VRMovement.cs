using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float Speed = 8;
    public float playerHeight = 1.6f;
    public Transform director;

    private VRInput input;
    private Rigidbody body;

    private Vector3 plane = new Vector3(1, 0, 1);

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        input = GetComponent<VRInput>();
        if (!director)
            director = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        var forward = new Vector3(director.forward.x, 0, director.forward.z).normalized;
        var right = new Vector3(director.right.x, 0, director.right.z).normalized;

        // Controller movement
        transform.Translate(right * input.LeftController.GetAxis(VRAxis.primaryX) * Time.deltaTime * Speed);
        transform.Translate(forward * input.LeftController.GetAxis(VRAxis.primaryY) * Time.deltaTime * Speed);

        // Keyboard movement
        transform.Translate(right * Input.GetAxis("Horizontal") * Time.deltaTime * Speed);
        transform.Translate(forward * Input.GetAxis("Vertical") * Time.deltaTime * Speed);

        // Adjust height
        if (Physics.Raycast(transform.position, Vector3.down, out var hit))
            if (hit.distance != playerHeight)
                transform.Translate(Vector3.up * (playerHeight - hit.distance));

        // Turn body
        transform.Rotate(0, input.RightController.GetAxis(VRAxis.primaryX), 0);
    }
}
