using System;
using System.Collections.Generic;
using UnityEngine;

namespace Explorer4D.Player
{
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour
    {
        // Set in Unity
        public float Sensitivity = 1f;

        public float Pitch = 0f;
        public float Yaw = 0f;
        public float Roll = 0f;

        private Camera camera;

        public void Awake()
        {
            camera = GetComponent<Camera>();
        }

        public void Update()
        {
            Yaw += Input.GetAxis("Mouse X") * Sensitivity;
            Pitch -= Input.GetAxis("Mouse Y") * Sensitivity;
            Pitch = Mathf.Clamp(Pitch, -80, 80);

            camera.transform.rotation = Quaternion.Euler(Pitch, Yaw, Roll);
        }
    }
}
