using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour
    {
        // Set in Unity
        public float Sensitivity = 3f;

        private Camera camera;

        public void Awake()
        {
            camera = GetComponent<Camera>();
        }

        public void Update()
        {
            float yaw = camera.transform.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
            float pitch = camera.transform.localRotation.eulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;
            //pitch = Mathf.Clamp(pitch, -80, 80);
            float roll = camera.transform.localRotation.eulerAngles.z;

            camera.transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }
    }
}
