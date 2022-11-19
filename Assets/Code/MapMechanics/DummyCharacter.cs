using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class DummyCharacter : MonoBehaviour
{
    [SerializeField] private float force;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector2.up * force);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidbody.AddForce(Vector2.left * force);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody.AddForce(Vector2.down * force);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * force);
        }
    }
}