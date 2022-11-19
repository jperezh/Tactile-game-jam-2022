using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
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

    public void OnOff(bool isOn)
    {
        forceField.enabled = isOn;
        Debug.Log("Is On? " + isOn);
    }
    
}
