using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Debugging
{
    [RequireComponent(typeof(Polyhedron))]
    public class LogVertices : MonoBehaviour
    {
        public Polyhedron Polyhedron { get; private set; }

        private float lastLogTime;
        private float secondsPerLog = 1.0f;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        public void Start()
        {
            lastLogTime = Time.time;
        }

        public void Update()
        {
            if (Time.time - lastLogTime > secondsPerLog)
            {
                string message = "--- Vertices ---\n\n";

                message += "Local:\n";
                for (int i = 0; i < Polyhedron.Vertices.Length; i++)
                {
                    var v = Polyhedron.Vertices[i].LocalPosition;
                    message += String.Format("V{0} - X:{1} Y:{2} Z:{3}\n", i, v.x, v.y, v.z);
                }

                message += "\nGlobal:\n";
                for (int i = 0; i < Polyhedron.Vertices.Length; i++)
                {
                    var v = Polyhedron.Vertices[i].GlobalPosition;
                    message += String.Format("V{0} - X:{1} Y:{2} Z:{3}\n", i, v.x, v.y, v.z);
                }

                Debug.Log(message);
                lastLogTime = Time.time;
            }
        }
    }
}
