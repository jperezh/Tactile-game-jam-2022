using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeLauncher : MonoBehaviour
{
    [SerializeField] private float spawnDuration;
    [SerializeField] private Vector2 throwDirection;
    [SerializeField] private float maxTorque;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private Block[] blockPrefabs;

    private float spawnTimer;
    private Vector2 halfSize;
    private Transform shapesRoot;

    private void Start()
    {
        shapesRoot = new GameObject("ShapesRoot").GetComponent<Transform>();
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
        var randomBlockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
        var randomBlock = Instantiate(randomBlockPrefab, transform.position, Quaternion.identity, shapesRoot);
        var rigidbody = randomBlock.GetComponent<Rigidbody2D>();

        var randomTorque = Random.Range(-maxTorque, maxTorque);
        rigidbody.AddTorque(randomTorque, ForceMode2D.Impulse);

        var randomForce = throwDirection * Random.Range(minForce, maxForce);
        rigidbody.AddForce(randomForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        var position = transform.position;
        var nextPoint = position + (Vector3)throwDirection;
        Gizmos.DrawLine(position, nextPoint);
    }
}