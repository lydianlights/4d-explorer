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

        private GeneratedPolyhedron projectionPolyhedron;
        private GameObject projection;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        // Run on object load
        public void Start()
        {
            GenerateProjectionPolyhedron();
        }

        // Run each frame
        public void Update()
        {
            UpdateProjectionPolyhedron();
        }

        private void GenerateProjectionPolyhedron()
        {
            DestroyImmediate(projection);
            projection = new GameObject("Stereographic Projection");
            projection.transform.SetParent(gameObject.transform);

            // TODO: Add edge generation
            projectionPolyhedron = Polyhedron.GenerateFor(projection, (Polyhedron self, ref Vertex[] vertices, ref Edge[] edges) =>
            {
                vertices = new Vertex[Polyhedron.Vertices.Length];
                for (int i = 0; i < vertices.Length; i++)
                {
                    Vector3 result = Project(Polyhedron.Vertices[i].GlobalPosition);
                    vertices[i] = new Vertex(self, i, result);
                }

                edges = new Edge[Polyhedron.Edges.Length];
                for (int i = 0; i < edges.Length; i++)
                {
                    int indexA = Polyhedron.Edges[i].Endpoints[0].Index;
                    int indexB = Polyhedron.Edges[i].Endpoints[1].Index;
                    edges[i] = new Edge(vertices[indexA], vertices[indexB]);
                }
            });

            projection.AddComponent<RenderWireframe>();
        }

        private void UpdateProjectionPolyhedron()
        {
            for (int i = 0; i < projectionPolyhedron.Vertices.Length; i++)
            {
                Vector3 result = Project(Polyhedron.Vertices[i].GlobalPosition);
                projectionPolyhedron.Vertices[i].LocalPosition = result;
            }
        }

        public static Vector3 Project(Vector3 target)
        {
            return new Vector3(target.x, 0, target.z);
        }
    }
}
