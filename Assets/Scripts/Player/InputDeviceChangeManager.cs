using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputDeviceChangeManager : MonoBehaviour
{
    private PlayerInputs playerInput;
    private Transform playerTransform;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        PlayerInput input = FindObjectOfType<PlayerInput>();
        playerControllerScript = playerTransform.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        InputUser.onChange += InputDeviceChanged;
    }

    private void OnDisable()
    {
        InputUser.onChange -= InputDeviceChanged;
    }

    private void InputDeviceChanged(InputUser user, InputUserChange change, InputDevice device)
    {
        Debug.Log("Here");
        if (change == InputUserChange.ControlSchemeChanged)
        {
            UpdateControls(user.controlScheme.Value.name);
        }
    }

    private void UpdateControls(string deviceName)
    {
        if (deviceName == "Gamepad")
        {
            playerControllerScript.isGamepad = true;
        }
        else
        {
            playerControllerScript.isGamepad = false;
        }
    }
}
