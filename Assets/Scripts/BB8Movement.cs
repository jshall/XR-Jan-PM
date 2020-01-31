using System.Linq;
using UnityEngine;

public class BB8Movement : MonoBehaviour
{
    public float RotationSpeed = 100;
    public KeyCode Dash = KeyCode.LeftShift;
    public GameObject Head;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Head.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

        var input = new Vector3(Input.GetAxis("Vertical"), Head.transform.rotation.y, -Input.GetAxis("Horizontal"));
        input *= Time.deltaTime * RotationSpeed * (Input.GetKey(Dash) ? 20 : 1);
        GetComponent<Rigidbody>().AddTorque(input, ForceMode.Impulse);
    }

}
