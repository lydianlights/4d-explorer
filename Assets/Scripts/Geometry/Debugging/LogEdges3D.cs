using System;
using System.Collections.Generic;
using UnityEngine;
using Explorer4D.Geometry.Shapes3D;

namespace Explorer4D.Geometry.Debugging
{
    [RequireComponent(typeof(Polyhedron))]
    public class LogEdges3D : MonoBehaviour
    {
        public Polyhedron Polyhedron { get; private set; }

        private float? lastLogTime = null;
        private float secondsPerLog = 2.0f;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        public void Update()
        {
            if (Time.time - lastLogTime > secondsPerLog || lastLogTime == null)
            {
                string message = "--- Edges ---\n";
                message += "Obj: " + gameObject.name + "\n\n";

                message += "Local:\n";
                for (int i = 0; i < Polyhedron.Edges.Length; i++)
                {
                    var a = Polyhedron.Edges[i].Endpoints[0].Index;
                    var b = Polyhedron.Edges[i].Endpoints[1].Index;
                    message += String.Format("E{0} [{1} <=> {2}]\n", i, a, b);
                }

                Debug.Log(message);
                lastLogTime = Time.time;
            }
        }
    }
}
