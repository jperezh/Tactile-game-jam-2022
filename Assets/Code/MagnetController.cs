using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 10f;
    [SerializeField] float moveSpeedVertical = 10f;
    [SerializeField] PointEffector2D forceField;
    [SerializeField] float magneticStreng = -100f;
    [SerializeField] float magneticDamping = 30f;
    [SerializeField] private Rigidbody2D magnetRigidbody;
    bool isOn;

    private void Start() {
        OnOff(false);
        forceField.drag = magneticDamping;
        forceField.forceMagnitude = magneticStreng;
    }

    public void Left()
    {
        // magnetRigidbody.AddForce(Vector2.left * moveSpeedHorizontal);
        transform.position = transform.position + Vector3.left * moveSpeedHorizontal *Time.fixedDeltaTime;
    }

    public void Right()
    {
        // magnetRigidbody.AddForce(Vector2.right * moveSpeedHorizontal);
        transform.position = transform.position + Vector3.right * moveSpeedHorizontal * Time.fixedDeltaTime;
    }

    public void Up()
    {
        // magnetRigidbody.AddForce(Vector2.up * moveSpeedVertical);
        transform.position = transform.position + Vector3.up * moveSpeedVertical * Time.fixedDeltaTime;
    }

    public void Down()
    {
        // magnetRigidbody.AddForce(Vector2.down * moveSpeedVertical);
        transform.position = transform.position + Vector3.down * moveSpeedVertical * Time.fixedDeltaTime;
    }

    public void OnOff(bool isOn)
    {
        forceField.enabled = isOn;
        Debug.Log("Is On? " + isOn);
    }
    
}
