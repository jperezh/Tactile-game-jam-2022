using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;

namespace Code
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float jumpForce = 500f;
        [SerializeField] private float groundingRaycastDistance = 5f;
        [SerializeField] private float groundingRaycastWidth = 0.5f;
        [SerializeField] private float jumpCooldown = 0.5f;
        [SerializeField] private float moveForce = 1f;
        [SerializeField] private float maxVelocity = 10f;
        [SerializeField] private AudioClip[] jumpClips;
        

        private const string GROUND_LAYER = "Ground";
        private const string CHARACTER_LAYER = "Character";
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        
        private Controls controls;
        private bool wasGrounded;
        private float lastTimeJumped;
        private bool isSpawned;
        private Animator animator;
        private AudioSource audioSource;
        
        public RuntimeAnimatorController AnimatorController
        {
            get
            {
                return GetComponentInChildren<Animator>().runtimeAnimatorController;
            }
            set
            {
                GetComponentInChildren<Animator>().runtimeAnimatorController = value;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            animator = GetComponentInChildren<Animator>();
            controls = new Controls();
            controls.Enable();
            playerInput.user.AssociateActionsWithUser(controls);

            if (!isSpawned)
            {
                rigidbody.gameObject.SetActive(false);
            }
        }

        public void Spawn(Vector3 position)
        {
            rigidbody.transform.position = position;
            rigidbody.gameObject.SetActive(true);
            isSpawned = true;
        }
        
        private void Update()
        {
            if (!isSpawned) return;

            bool isGrounded = IsGrounded();

            if (isGrounded && !wasGrounded)
            {
                //
            }
            
            if (IsGrounded() && !IsJumpInCooldown() && controls.InGame.Jump.WasPerformedThisFrame())
            {
                Jump();
                lastTimeJumped = Time.time;
            }
            
            wasGrounded = isGrounded;
        }

        private void FixedUpdate()
        {
            AddHorizontalForce();
            ClampVelocity();
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            var velocityMagnitude = rigidbody.velocity.magnitude;
            var inputValue = controls.InGame.Move.ReadValue<float>();
            
            var isRunning = inputValue != 0 || velocityMagnitude >= 1f;
            animator.SetBool(IsRunning, isRunning);
        }

        public void Rumble(float duration, float lowFrequencyNormalizedSpeed, float highFrequencyNormalizedSpeed)
        {
            StartCoroutine(RumbleCoroutine(duration, lowFrequencyNormalizedSpeed, highFrequencyNormalizedSpeed));
        }

        private IEnumerator RumbleCoroutine(float duration, float lowFrequencyNormalizedSpeed, float highFrequencyNormalizedSpeed)
        {
            var rumbleDevice = playerInput.devices.FirstOrDefault(d => d is IDualMotorRumble) as IDualMotorRumble;
            if (rumbleDevice == null) yield break;

            rumbleDevice.SetMotorSpeeds(lowFrequencyNormalizedSpeed, highFrequencyNormalizedSpeed);
            yield return new WaitForSecondsRealtime(duration);
            rumbleDevice.ResetHaptics();
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
            LayerMask groundLayerMask = LayerMask.GetMask(GROUND_LAYER, CHARACTER_LAYER);
            
            var raycastHit = Physics2D.Raycast(rigidbody.position, Vector2.down, groundingRaycastDistance, groundLayerMask);
            if (raycastHit.collider != null) return true;
            
            raycastHit = Physics2D.Raycast(rigidbody.position + Vector2.right * groundingRaycastWidth, Vector2.down, groundingRaycastDistance, groundLayerMask);
            if (raycastHit.collider != null) return true;
            
            raycastHit = Physics2D.Raycast(rigidbody.position - Vector2.right * groundingRaycastWidth, Vector2.down, groundingRaycastDistance, groundLayerMask);
            if (raycastHit.collider != null) return true;
            
            
            return false;
        }

        private void Jump()
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
            audioSource.PlayOneShot(jumpClips[Random.Range(0, jumpClips.Length)]);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            var startPos = rigidbody.position;
            Gizmos.DrawLine(startPos, startPos + Vector2.down * groundingRaycastDistance);

            startPos = rigidbody.position + Vector2.right * groundingRaycastWidth;
            Gizmos.DrawLine(startPos, startPos + Vector2.down * groundingRaycastDistance);
            
            startPos = rigidbody.position - Vector2.right * groundingRaycastWidth;
            Gizmos.DrawLine(startPos, startPos + Vector2.down * groundingRaycastDistance);
        }
    }
}