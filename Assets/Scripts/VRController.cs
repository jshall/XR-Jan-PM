using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/Manual/xr_input.html

public enum VRAxis { grip, trigger, primaryX, primaryY, secondaryX, secondaryY }
public enum VRButton { primaryClick, primaryTouch, secondaryClick, secondaryTouch, grip, trigger, menu, primaryStickClick, primaryStickTouch, secondaryStickClick }

public class VRController : MonoBehaviour
{
    public bool isLeftHand;

    public float gripValue => GetAxis(VRAxis.grip);
    public float triggerValue => GetAxis(VRAxis.trigger);

    public bool pressingPrimary => GetButton(VRButton.primaryClick);
    public bool touchingPrimary => GetButton(VRButton.primaryTouch);
    public bool pressingSecondary => GetButton(VRButton.secondaryClick);
    public bool touchingSecondary => GetButton(VRButton.secondaryTouch);
    public bool gripping => GetButton(VRButton.grip);
    public bool firing => GetButton(VRButton.trigger);
    public bool menu => GetButton(VRButton.menu);
    public bool pressingPrimaryJoystick => GetButton(VRButton.primaryStickClick);
    public bool touchingPrimaryJoystick => GetButton(VRButton.primaryStickTouch);
    public bool pressingSecondaryJoysick => GetButton(VRButton.secondaryStickClick);

    public Vector2 primaryJoystick => new Vector2(GetAxis(VRAxis.primaryX), GetAxis(VRAxis.primaryY));
    public Vector2 secondaryJoystick => new Vector2(GetAxis(VRAxis.secondaryX), GetAxis(VRAxis.secondaryY));

    public Vector3 velocity;
    public float gripForce = 100;

    public VRInput VRInput;

    private int hand => isLeftHand ? 0 : 1;
    private readonly string[,] axisName;
    private readonly KeyCode[,] buttonCode;
    private Vector3 lastPosition;

    public VRController()
    {
        axisName = new string[2, Enum.GetNames(typeof(VRAxis)).Length];
        for (var hand = 0; hand < 2; hand++)
        {
            var prefix = hand == 0 ? "Left " : "Right ";
            axisName[hand, (int)VRAxis.grip] = prefix + "Grip";
            axisName[hand, (int)VRAxis.trigger] = prefix + "Trigger";
            axisName[hand, (int)VRAxis.primaryX] = prefix + "X Primary";
            axisName[hand, (int)VRAxis.primaryY] = prefix + "Y Primary";
            axisName[hand, (int)VRAxis.secondaryX] = prefix + "X Secondary";
            axisName[hand, (int)VRAxis.secondaryY] = prefix + "Y Secondary";
        }
        buttonCode = new KeyCode[,]
        {
            { KeyCode.JoystickButton2, KeyCode.JoystickButton12, KeyCode.JoystickButton3,
              KeyCode.JoystickButton13, KeyCode.JoystickButton4, KeyCode.JoystickButton14,
              KeyCode.JoystickButton6, KeyCode.JoystickButton8, KeyCode.JoystickButton16,
              KeyCode.JoystickButton18 },
            { KeyCode.JoystickButton0, KeyCode.JoystickButton10, KeyCode.JoystickButton1,
              KeyCode.JoystickButton11, KeyCode.JoystickButton5, KeyCode.JoystickButton15,
              KeyCode.JoystickButton7, KeyCode.JoystickButton9, KeyCode.JoystickButton17,
              KeyCode.JoystickButton19 }
        };
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    public float GetAxis(VRAxis axis) => Input.GetAxis(axisName[hand, (int)axis]);
    public bool GetButton(VRButton button) => Input.GetKey(buttonCode[hand, (int)button]);
    public bool GetButtonUp(VRButton button) => Input.GetKeyUp(buttonCode[hand, (int)button]);
    public bool GetButtonDown(VRButton button) => Input.GetKeyDown(buttonCode[hand, (int)button]);
}
