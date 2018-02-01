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
        public float MoveSpeed = 10f;

        [NonSerialized]
        public Vector3 Velocity = new Vector3(0, 0, 0);
        [NonSerialized]
        public PlayerCamera Camera;

        private CharacterController control;
        private Vector3 moveDirection = new Vector3(0, 0, 0);

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
            var facing = Quaternion.Euler(0, Camera.Yaw, 0);
            moveDirection = facing * new Vector3(
                Input.GetAxis("Strafe"),
                0,
                Input.GetAxis("Forward")
            );
        }

        // Run every physics frame
        public void FixedUpdate()
        {
            Velocity.x = moveDirection.x * MoveSpeed;
            Velocity.z = moveDirection.z * MoveSpeed;
            Velocity.y -= Time.deltaTime * Gravity;
            if (control.isGrounded)
            {
                Velocity.y = 0;
            }

            control.Move(Time.deltaTime * Velocity);
        }
    }
}