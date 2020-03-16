using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInput : MonoBehaviour
{
    public Canvas LeftPanel;

    public Slider LeftTriggerAxis;

    public Toggle LeftJoystickTouch;
    public Toggle LeftJoystickPress;
    public Slider LeftJoystickAxisX;
    public Slider LeftJoystickAxisY;

    public Toggle LeftSecondaryTouch;
    public Toggle LeftSecondaryPress;

    public Toggle LeftPrimaryTouch;
    public Toggle LeftPrimaryPress;

    public Toggle LeftMenuPress;

    public Slider LeftGripAxis;

    public Canvas RightPanel;

    public Slider RightTriggerAxis;

    public Toggle RightJoystickTouch;
    public Toggle RightJoystickPress;
    public Slider RightJoystickAxisX;
    public Slider RightJoystickAxisY;

    public Toggle RightSecondaryTouch;
    public Toggle RightSecondaryPress;

    public Toggle RightPrimaryTouch;
    public Toggle RightPrimaryPress;

    public Toggle RightMenuPress;

    public Slider RightGripAxis;

    private VRInput input;

    void Awake()
    {
        input = GetComponent<VRInput>();
        LeftPanel.enabled = RightPanel.enabled = false;
    }

    void Update()
    {
        if ((input.LeftController.GetButton(VRButton.secondaryClick) && input.RightController.GetButtonDown(VRButton.secondaryClick)) ||
            (input.LeftController.GetButtonDown(VRButton.secondaryClick) && input.RightController.GetButton(VRButton.secondaryClick)))
            LeftPanel.enabled = RightPanel.enabled = !RightPanel.enabled;

        LeftTriggerAxis.value = input.LeftController.triggerValue;
        LeftJoystickTouch.isOn = input.LeftController.touchingPrimaryJoystick;
        LeftJoystickPress.isOn = input.LeftController.pressingPrimaryJoystick;
        LeftJoystickAxisX.value = (input.LeftController.primaryJoystick.x + 1) / 2;
        LeftJoystickAxisY.value = (input.LeftController.primaryJoystick.y + 1) / 2;
        LeftSecondaryTouch.isOn = input.LeftController.touchingSecondary;
        LeftSecondaryPress.isOn = input.LeftController.pressingSecondary;
        LeftPrimaryTouch.isOn = input.LeftController.touchingPrimary;
        LeftPrimaryPress.isOn = input.LeftController.pressingPrimary;
        LeftMenuPress.isOn = input.LeftController.menu;
        LeftGripAxis.value = input.LeftController.gripValue;
        RightTriggerAxis.value = input.RightController.triggerValue;
        RightJoystickTouch.isOn = input.RightController.touchingPrimaryJoystick;
        RightJoystickPress.isOn = input.RightController.pressingPrimaryJoystick;
        RightJoystickAxisX.value = (input.RightController.primaryJoystick.x + 1) / 2;
        RightJoystickAxisY.value = (input.RightController.primaryJoystick.y + 1) / 2;
        RightSecondaryTouch.isOn = input.RightController.touchingSecondary;
        RightSecondaryPress.isOn = input.RightController.pressingSecondary;
        RightPrimaryTouch.isOn = input.RightController.touchingPrimary;
        RightPrimaryPress.isOn = input.RightController.pressingPrimary;
        RightMenuPress.isOn = input.RightController.menu;
        RightGripAxis.value = input.RightController.gripValue;
    }
}
