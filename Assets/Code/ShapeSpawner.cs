using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDuration;
    [SerializeField] private BoxCollider2D spawnArea;
    [SerializeField] private Block[] blockPrefabs;

    private float spawnTimer;
    private Vector2 halfSize;
    private Transform shapesRoot;

    private void Start()
    {
        shapesRoot = new GameObject("ShapesRoot").GetComponent<Transform>();
        halfSize = spawnArea.size / 2;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDuration)
        {
            spawnTimer = 0f;
            SpawnRandomBlock();
        }
    }

    private void SpawnRandomBlock()
    {
        var randomPos = transform.position + new Vector3(Random.Range(-halfSize.x, halfSize.x), 
            Random.Range(-halfSize.y, halfSize.y));

        var randomBlock = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
        Instantiate(randomBlock, randomPos, Quaternion.identity, shapesRoot);
    }
}
