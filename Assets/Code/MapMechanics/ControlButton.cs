using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
public class ControlButton : MonoBehaviour
{
    [SerializeField] private MagnetActions buttonAction;
    [SerializeField] private CraneController craneController;
    [SerializeField] private MagnetController magnetController;

    private void OnTriggerStay2D(Collider2D col) {
        MoveMagnet();
    }

    private void MoveMagnet() {
        switch (buttonAction) {
            case MagnetActions.MoveLeft:
                craneController.Left();
                break;
            case MagnetActions.MoveRight:
                craneController.Right();
                break;
            case MagnetActions.MoveUp:
                craneController.Up();
                break;
            case MagnetActions.MoveDown:
                craneController.Down();
                break;
            case MagnetActions.On:
                magnetController.OnOff(true);
                break;
            case MagnetActions.Off:
                magnetController.OnOff(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}