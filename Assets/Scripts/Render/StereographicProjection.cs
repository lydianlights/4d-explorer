using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polyhedron))]
    public class StereographicProjection : MonoBehaviour
    {
        public Polyhedron Polyhedron { get; private set; }

        private GameObject projection;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        public void Start()
        {
            GenerateProjectionPolyhedron();
        }

        private void GenerateProjectionPolyhedron()
        {
            DestroyImmediate(projection);
            projection = new GameObject("Stereographic Projection");
            projection.transform.SetParent(gameObject.transform);

            // TODO: Generate projection instead of test
            Polyhedron.GenerateFor(projection, (Polyhedron self, ref Vertex[] vertices, ref Edge[] edges) =>
            {
                vertices = new Vertex[]
                {
                    new Vertex(self, Mathf.Sqrt(8f/9f), -1f/3f, 0f),
                    new Vertex(self, -Mathf.Sqrt(2f/9f), -1f/3f, Mathf.Sqrt(2f/3f)),
                    new Vertex(self, -Mathf.Sqrt(2f/9f), -1f/3f, -Mathf.Sqrt(2f/3f)),
                    new Vertex(self, 0f, 1f, 0f),
                };

                edges = new Edge[]
                {
                    new Edge(vertices[0], vertices[1]),
                    new Edge(vertices[0], vertices[2]),
                    new Edge(vertices[0], vertices[3]),
                    new Edge(vertices[1], vertices[2]),
                    new Edge(vertices[1], vertices[3]),
                    new Edge(vertices[2], vertices[3]),
                };
            });

            projection.AddComponent<RenderWireframe>();
        }
    }
}
