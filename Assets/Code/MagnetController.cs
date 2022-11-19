using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 10f;
    [SerializeField] float moveSpeedVertical = 10f;
    [SerializeField] PointEffector2D forceField;
    [SerializeField] float magneticStreng = -100;
    [SerializeField] private Rigidbody2D magnetRigidbody;
    bool isOn;

    public void Left()
    {
        magnetRigidbody.AddForce(Vector2.left * moveSpeedHorizontal);
    }

    public void Right()
    {
        magnetRigidbody.AddForce(Vector2.right * moveSpeedHorizontal);
    }

    public void Up()
    {
        magnetRigidbody.AddForce(Vector2.up * moveSpeedVertical);
    }

    public void Down()
    {
        magnetRigidbody.AddForce(Vector2.down * moveSpeedVertical);
    }

    public void OnOff(bool isOn)
    {
        isOn = !isOn;
        if (isOn)
        {
            forceField.forceMagnitude = magneticStreng;
        }

        else
        {
            forceField.forceMagnitude = 0;
        }
        Debug.Log("Is On? " + isOn);
    }
    
}
