using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour
    {
        // Set in Unity
        public float Sensitivity = 1f;
        public float pitch = 0f;
        public float yaw = 0f;
        public float roll = 0f;

        private Camera camera;

        public void Awake()
        {
            camera = GetComponent<Camera>();
        }

        public void Update()
        {
            yaw += Input.GetAxis("Mouse X") * Sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * Sensitivity;
            pitch = Mathf.Clamp(pitch, -80, 80);

            camera.transform.rotation = Quaternion.Euler(pitch, yaw, roll);
        }
    }
}
