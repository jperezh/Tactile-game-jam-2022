using UnityEngine;

namespace Code
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float jumpForce = 500f;
        [SerializeField] private float groundingRaycastDistance = 5f;
        [SerializeField] private float jumpCooldown = 0.5f;
        [SerializeField] private float moveForce = 1f;
        [SerializeField] private float maxVelocity = 10f;

        private const string GROUND_LAYER = "Ground";
        
        private Controls controls;
        private bool wasGrounded;
        private float lastTimeJumped;

        private void Start()
        {
            controls = new Controls();
            controls.Enable();
        }
        private void Update()
        {
            if (IsGrounded() && !IsJumpInCooldown() && controls.InGame.Jump.WasPerformedThisFrame())
            {
                Jump();
                lastTimeJumped = Time.time;
            }

            AddHorizontalForce();
            ClampVelocity();
        }

        private void ClampVelocity()
        {
            var horizontalVelocity = rigidbody.velocity.x;
            horizontalVelocity = Mathf.Clamp(horizontalVelocity, -maxVelocity, maxVelocity);

            rigidbody.velocity = new Vector2(horizontalVelocity, rigidbody.velocity.y);
        }

        private void AddHorizontalForce()
        {
            var inputValue = controls.InGame.Move.ReadValue<float>();
            rigidbody.AddForce(Vector2.right * inputValue * moveForce);
        }

        private bool IsJumpInCooldown()
        {
            return Time.time - lastTimeJumped < jumpCooldown;
        }

        private bool IsGrounded()
        {
            LayerMask groundLayerMask = LayerMask.GetMask(GROUND_LAYER);
            var raycastHit = Physics2D.Raycast(rigidbody.position, Vector2.down, groundingRaycastDistance, groundLayerMask);

            return raycastHit.collider != null;
        }

        private void Jump()
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rigidbody.position, rigidbody.position + Vector2.down * groundingRaycastDistance);
        }
    }
}