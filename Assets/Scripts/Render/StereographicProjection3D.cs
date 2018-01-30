using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes3D;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polyhedron))]
    public class StereographicProjection3D : MonoBehaviour
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
            projectionPolyhedron = Polyhedron.GenerateFor(
                projection,
                (self) =>
                {
                    var vertexPositions = new Vector3[Polyhedron.Vertices.Length];
                    for (int i = 0; i < vertexPositions.Length; i++)
                    {
                        vertexPositions[i] = Project(Polyhedron.Vertices[i].GlobalPosition);
                    }
                    return vertexPositions;
                },
                (self) =>
                {
                    var edges = new Edge3D[Polyhedron.Edges.Length];
                    for (int i = 0; i < edges.Length; i++)
                    {
                        int indexA = Polyhedron.Edges[i].Endpoints[0].Index;
                        int indexB = Polyhedron.Edges[i].Endpoints[1].Index;
                        edges[i] = new Edge3D(self.Vertices[indexA], self.Vertices[indexB]);
                    }
                    return edges;
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
