using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float Speed = 8;
    private Camera Camera;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * Speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * Speed);
        if (Input.GetKey(KeyCode.Space)) transform.Translate(Vector3.up * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift)) transform.Translate(Vector3.down * Time.deltaTime);

        // Move head and camera
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        if (Camera != null)
        {
            Camera.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
            Camera.transform.Translate(0, 0, Input.mouseScrollDelta.y);
        }
    }
}
