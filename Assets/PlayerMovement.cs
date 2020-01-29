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
        var Speed = Time.deltaTime * WalkingSpeed;
        if (Input.GetKey(Dash))
            Speed *= 2;
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Speed);
        transform.Rotate(0, RotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
    }

}
