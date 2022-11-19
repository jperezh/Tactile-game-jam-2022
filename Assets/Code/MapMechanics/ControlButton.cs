using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ControlButton : MonoBehaviour
{
    public static event Action<bool> TriggerStateChange;
    
    [SerializeField] private MagnetActions buttonAction;
    [SerializeField] private CraneController craneController;
    [SerializeField] private MagnetController magnetController;
    [SerializeField] private GameObject activePivot;
    [SerializeField] private GameObject inactivePivot;

    private void OnTriggerStay2D(Collider2D col) {
        MoveMagnet();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        activePivot.SetActive(false);
        inactivePivot.SetActive(true);
        TriggerStateChange?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        activePivot.SetActive(true);
        inactivePivot.SetActive(false);
        TriggerStateChange?.Invoke(false);
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