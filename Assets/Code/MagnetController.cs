using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    bool isOn;

    public void Left()
    {
        Debug.Log("Left");
    }

    public void Right()
    {
        Debug.Log("Right");
    }

    public void Up()
    {
        Debug.Log("Up");
    }

    public void Down()
    {
        Debug.Log("Down");
    }

    public void Swith(bool isOn)
    {
        isOn = !isOn;
        Debug.Log("Is On? " + isOn);
    }


    // [SerializeField] float moveSpeed = 1f;
    // [SerializeField] Effector2D forceField;

    // Vector2 moveInput;
    // bool isOn;

    // private void OnEnable()
    // {
    //     if (inputSys == null)
    //     {
    //         inputSys  = new InputSystem();
    //         inputSys.Magnet.Movement.performed += Movement;
    //         inputSys.Magnet.Switch.started += Switch;
    //     }
    //     inputSys.Enable();

    // }

    // private void Movement(InputAction.CallbackContext context)
    // {
    //     moveInput = context.ReadValue<Vector2>().normalized;
    // }

    // private void Switch(InputAction.CallbackContext context)
    // {
    //     isOn = !isOn;
    // }

    // private void OnDisable()
    // {
    //     inputSys.Disable();
    // }

    // private void Start()
    // {
    //     magnet = GetComponent<CharacterController>();
    // }

    // private void Update() {
    //     float newX = transform.position.x + moveInput.x * moveSpeed * Time.deltaTime;
    //     float newY = transform.position.y + moveInput.y * moveSpeed * Time.deltaTime;
    //     transform.position = new Vector2 (newX,newY);
    //     forceField.enabled = isOn;
    // }
}
