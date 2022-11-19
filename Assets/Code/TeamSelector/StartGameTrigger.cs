using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameTrigger : MonoBehaviour
{
    private readonly List<PlayerInput> playersPressing = new List<PlayerInput>();

    public event Action PressStarted;
    public event Action PressEnded;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerInput = other.gameObject.GetComponentInParent<PlayerInput>();
        if (playerInput == null) return;
        
        if (!playersPressing.Any())
        {
            PressStarted?.Invoke();
        }
        playersPressing.Add(playerInput);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var playerInput = other.gameObject.GetComponentInParent<PlayerInput>();
        if (playerInput == null) return;

        playersPressing.Remove(playerInput);
        if (!playersPressing.Any())
        {
            PressEnded?.Invoke();
        }
    }
}
