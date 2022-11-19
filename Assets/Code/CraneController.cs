using UnityEngine;

public class CraneController : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 5;
    [SerializeField] float moveSpeedVertical = 5;
    
    public void Left()
    {
        // magnetRigidbody.AddForce(Vector2.left * moveSpeedHorizontal);
        transform.position = transform.position + Vector3.left * moveSpeedHorizontal *Time.fixedDeltaTime;
    }

    public void Right()
    {
        // magnetRigidbody.AddForce(Vector2.right * moveSpeedHorizontal);
        transform.position = transform.position + Vector3.right * moveSpeedHorizontal * Time.fixedDeltaTime;
    }

    public void Up()
    {
        // magnetRigidbody.AddForce(Vector2.up * moveSpeedVertical);
        transform.position = transform.position + Vector3.up * moveSpeedVertical * Time.fixedDeltaTime;
    }

    public void Down()
    {
        // magnetRigidbody.AddForce(Vector2.down * moveSpeedVertical);
        transform.position = transform.position + Vector3.down * moveSpeedVertical * Time.fixedDeltaTime;
    }
}
