using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float WalkingSpeed = 5;
    public float RotationSpeed = 100;
    public KeyCode Dash = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var walk = new Vector3(0, 0, Time.deltaTime * WalkingSpeed);
        if (Input.GetKey(Dash))
            walk *= 2;
        var r = gameObject.GetComponent<Rigidbody>();
        r.AddRelativeForce(walk * Input.GetAxis("Vertical"), ForceMode.Acceleration);
        r.AddTorque(0, RotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, ForceMode.Acceleration);
    }

}
