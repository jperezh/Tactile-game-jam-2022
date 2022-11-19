using Code;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;

    private void Start()
    {
        var allCharacters = FindObjectsOfType<Character>();

        int index = 0;
        foreach (var character in allCharacters)
        {
            character.Spawn(spawnPositions[index].position);
            index = index + 1;
        }
    }
}
