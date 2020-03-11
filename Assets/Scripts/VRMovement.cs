using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float Speed = 8;

    private Transform head;
    private VRInput input;

    private Vector3 plane = new Vector3(1, 0, 1);

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        input = GetComponent<VRInput>();
        head = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        transform.Translate(Vector3.Cross(head.right, plane) * input.LeftController.GetAxis(VRAxis.primaryX) * Time.deltaTime * Speed);
        transform.Translate(Vector3.Cross(head.forward, plane) * input.LeftController.GetAxis(VRAxis.primaryY) * Time.deltaTime * Speed);

        // Turn body
        transform.Rotate(0, input.RightController.GetAxis(VRAxis.primaryX), 0);
    }
}
