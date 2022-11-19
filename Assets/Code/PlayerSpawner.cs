using Code;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private Transform spawnPosition;

    private void Start()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        var character = input.GetComponent<Character>();
        var targetSpawnPosition = spawnPosition == null
            ? Vector3.zero
            : spawnPosition.position;
        
        character.Spawn(targetSpawnPosition);
    }
}
