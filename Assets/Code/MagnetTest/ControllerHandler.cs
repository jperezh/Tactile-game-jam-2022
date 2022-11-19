using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Effector2D forceField;

    InputSystem inputSys;
    Vector2 moveInput;
    bool isOn;

    private void OnEnable()
    {
        if (inputSys == null)
        {
            inputSys = new InputSystem();
            inputSys.Magnet.Movement.performed += Movement;
            inputSys.Magnet.Switch.started += Switch;
        }

        inputSys.Enable();
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Debug.Log("performed Movement");
        moveInput = context.ReadValue<Vector2>().normalized;
    }

    private void Switch(InputAction.CallbackContext context)
    {
        Debug.Log("Started Switch");
        isOn = !isOn;
        // forceField.enabled = isOn;
    }

    private void OnDisable()
    {
        inputSys.Disable();
    }

    private void Update()
    {
        float newX = transform.position.x + moveInput.x * speed * Time.deltaTime;
        float newY = transform.position.y + moveInput.y * speed * Time.deltaTime;
        transform.position = new Vector2(newX, newY);

        if (forceField != null)
        {
            forceField.enabled = isOn;
        }
    }
}