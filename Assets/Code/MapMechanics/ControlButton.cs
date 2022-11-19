using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ControlButton : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log($"[Jaime]: OnTriggerStay");
    }
}
