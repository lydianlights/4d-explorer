using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Geometry4D;
using Scripts.Geometry4D.Shapes;

namespace Scripts.Debugging
{
    [RequireComponent(typeof(Polytope4D))]
    public class LogVertices4D : MonoBehaviour
    {
        public Polytope4D Polytope { get; private set; }

        private float? lastLogTime = null;
        private float secondsPerLog = 2.0f;

        // Run on script load
        public void Awake()
        {
            Polytope = GetComponent<Polytope4D>();
        }

        public void Update()
        {
            if (Time.time - lastLogTime > secondsPerLog || lastLogTime == null)
            {
                string message = "--- Vertices ---\n";
                message += "Obj: " + gameObject.name + "\n\n";

                message += "Local:\n";
                for (int i = 0; i < Polytope.Vertices.Length; i++)
                {
                    var v = Polytope.Vertices[i].LocalPosition;
                    message += String.Format("V{0} - X:{1} Y:{2} Z:{3} W:{4}\n", i, v.x, v.y, v.z, v.w);
                }

                message += "\nGlobal:\n";
                for (int i = 0; i < Polytope.Vertices.Length; i++)
                {
                    var v = Polytope.Vertices[i].GlobalPosition;
                    message += String.Format("V{0} - X:{1} Y:{2} Z:{3} W:{4}\n", i, v.x, v.y, v.z, v.w);
                }

                Debug.Log(message);
                lastLogTime = Time.time;
            }
        }
    }
}
