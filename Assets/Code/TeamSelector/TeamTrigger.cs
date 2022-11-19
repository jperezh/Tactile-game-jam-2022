using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.TeamSelector
{
    public class TeamTrigger : MonoBehaviour
    {
        public event Action<PlayerInput> PlayerEntered;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var playerInput = col.gameObject.GetComponentInParent<PlayerInput>();
            if (playerInput != null)
            {
                PlayerEntered?.Invoke(playerInput);
            }
        }
    }
}