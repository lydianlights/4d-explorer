using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        // Set in Unity
        [SerializeField]
        private PlayerCamera cameraPrefab;
        public float Gravity = 20f;
        public float MaxMoveSpeed = 10f;
        public float Acceleration = 100f;
        public float JumpStrength = 5f;
        public float AirAcceleration = 10f;

        [NonSerialized]
        public Vector3 Velocity = new Vector3(0, 0, 0);
        public Vector3 HorizontalVelocity
        {
            get
            {
                return new Vector3(Velocity.x, 0, Velocity.z);
            }
        }
        [NonSerialized]
        public PlayerCamera Camera;

        private CharacterController control;
        private Vector3 moveDirection = new Vector3(0, 0, 0);
        private bool isJumpPressed = false;

        // Run on script load
        public void Awake()
        {
            control = GetComponent<CharacterController>();
            Camera = Instantiate(cameraPrefab, gameObject.transform);
        }

        // Run on object load
        public void Start()
        {

        }

        // Run every frame
        public void Update()
        {
            SetMovementDirectionFromPlayerInput();
        }

        // Run every physics frame
        public void FixedUpdate()
        {
            MovePlayer();
        }

        private void SetMovementDirectionFromPlayerInput()
        {
            var facing = Quaternion.Euler(0, Camera.Yaw, 0);
            moveDirection = facing * new Vector3(
                Input.GetAxis("Strafe"),
                0,
                Input.GetAxis("Forward")
            );
            moveDirection.Normalize();
            
            if (Input.GetButtonDown("Jump") && control.isGrounded)
            {
                isJumpPressed = true;
            }
        }

        private void MovePlayer()
        {
            CalculateVelocity();
            control.Move(Time.deltaTime * Velocity);
        }

        private void CalculateVelocity()
        {
            var acceleration = (control.isGrounded) ? Acceleration : AirAcceleration;
            if (moveDirection != Vector3.zero)
            {
                Velocity += Time.deltaTime * acceleration * moveDirection;
            }
            else
            {
                // Deccelerate if no player input
                bool signX = (HorizontalVelocity.x > 0f);
                bool signZ = (HorizontalVelocity.z > 0f);

                acceleration = -acceleration;
                Velocity += Time.deltaTime * acceleration * HorizontalVelocity.normalized;

                bool newSignX = (Velocity.x > 0f);
                bool newSignZ = (Velocity.z > 0f);
                
                if (signX != newSignX || signZ != newSignZ)
                {
                    Velocity.x = 0;
                    Velocity.z = 0;
                }
            }

            if (HorizontalVelocity.magnitude > MaxMoveSpeed)
            {
                float sf = MaxMoveSpeed / HorizontalVelocity.magnitude;
                Velocity.Scale(new Vector3(sf, 1, sf));
            }

            Velocity.y -= Time.deltaTime * Gravity;
            if (control.isGrounded)
            {
                Velocity.y = -control.stepOffset / Time.deltaTime;
                if (isJumpPressed)
                {
                    Velocity.y = JumpStrength;
                    isJumpPressed = false;
                }
            }
        }
    }
}