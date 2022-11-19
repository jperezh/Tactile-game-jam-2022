using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ControlButton : MonoBehaviour
{
    [SerializeField] private MagnetActions buttonAction;
    [SerializeField] private MagnetController magnetController;

    private void OnTriggerStay2D(Collider2D col) {
        MoveMagnet();
    }

    private void MoveMagnet() {
        switch (buttonAction) {
            case MagnetActions.MoveLeft:
                magnetController.Left();
                break;
            case MagnetActions.MoveRight:
                magnetController.Right();
                break;
            case MagnetActions.MoveUp:
                magnetController.Left();
                break;
            case MagnetActions.MoveDown:
                magnetController.Down();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}