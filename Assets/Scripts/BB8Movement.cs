using System.Linq;
using UnityEngine;

public class BB8Movement : MonoBehaviour
{
    public float RotationSpeed = 8;
    public KeyCode Dash = KeyCode.LeftShift;
    public float DashMultiplier = 3;
    public GameObject Head;
    private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame1
    void Update()
    {
        Head.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        if (Camera != null)
        {
            Camera.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));
            Camera.transform.Translate(0, 0, Input.mouseScrollDelta.y);
        }
        var input = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        input *= Time.deltaTime * RotationSpeed * (Input.GetKey(Dash) ? DashMultiplier : 1);
        input = Head.transform.rotation * input;
        GetComponent<Rigidbody>().AddTorque(input, ForceMode.Impulse);
    }

}
