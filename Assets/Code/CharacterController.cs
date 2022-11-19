using UnityEngine;

namespace Code
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float jumpForce = 500f;
        [SerializeField] private float groundingRaycastDistance = 5f;

        private const string GROUND_LAYER = "Ground";
        
        private Controls controls;

        private void Start()
        {
            controls = new Controls();
            controls.Enable();
        }
        private void Update()
        {
            bool isGrounded = IsGrounded();
            
            if (isGrounded && controls.InGame.Jump.WasPerformedThisFrame())
            {
                Jump();
            }
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