using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Behaviors
{
    [RequireComponent(typeof(Polyhedron))]
    public class TestScaleVertices : MonoBehaviour
    {
        // Set by Unity
        public float Magnitude = 1.01f;

        public Polyhedron Polyhedron { get; private set; }

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        // Run every frame
        public void FixedUpdate()
        {
            foreach(Vertex vertex in Polyhedron.Vertices)
            {
                var m = 1 + Time.deltaTime * Magnitude;
                vertex.Position = new Vector3(
                    m * vertex.Position.x,
                    m * vertex.Position.y,
                    m * vertex.Position.z
                );
            }
        }
    }
}
