using System;
using System.Collections.Generic;
using UnityEngine;
using Explorer4D.Geometry.Debugging;
using Explorer4D.Geometry.Rendering;
using Explorer4D.Geometry.Shapes3D;
using Explorer4D.Geometry.Shapes4D;

namespace Explorer4D.Geometry.Projections
{
    // TODO: Color edges by w-axis "depth"
    [RequireComponent(typeof(Polytope4D))]
    public class PerspectiveProjection4D : MonoBehaviour
    {
        // Set in Unity
        public float ProjectionHeight = 1.5f;
        public bool LogVertices = false;
        public bool LogEdges = false;

        public Polytope4D Polytope { get; private set; }

        private GeneratedPolyhedron projectionPolyhedron;
        private GameObject projectionObj;

        // Run on script load
        public void Awake()
        {
            Polytope = GetComponent<Polytope4D>();
        }

        // Run on object load
        public void Start()
        {
            GenerateProjection();
        }

        // Run every frame
        public void Update()
        {
            UpdateProjection();
        }

        private void GenerateProjection()
        {
            DestroyImmediate(projectionObj);
            projectionObj = new GameObject("Perspective Projection");
            projectionObj.transform.SetParent(gameObject.transform);
            projectionObj.transform.localPosition = Vector3.zero;
            projectionObj.transform.localRotation = Quaternion.identity;
            projectionObj.transform.localScale= Vector3.one;

            projectionPolyhedron = Polyhedron.GenerateFor(
                projectionObj,
                (self) =>
                {
                    var vertexPositions = new Vector3[Polytope.Vertices.Length];
                    for (int i = 0; i < vertexPositions.Length; i++)
                    {
                        vertexPositions[i] = Project(Polytope.Vertices[i].GlobalPosition);
                    }
                    return vertexPositions;
                },
                (self) =>
                {
                    var edges = new Edge3D[Polytope.Edges.Length];
                    for (int i = 0; i < edges.Length; i++)
                    {
                        int indexA = Polytope.Edges[i].Endpoints[0].Index;
                        int indexB = Polytope.Edges[i].Endpoints[1].Index;
                        edges[i] = new Edge3D(self.Vertices[indexA], self.Vertices[indexB]);
                    }
                    return edges;
                }
            );

            projectionObj.AddComponent<RenderWireframe>();
            
            if (LogVertices) { projectionObj.AddComponent<LogVertices3D>(); }
            if (LogEdges) { projectionObj.AddComponent<LogEdges3D>(); }
        }

        public void UpdateProjection()
        {
            for (int i = 0; i < projectionPolyhedron.Vertices.Length; i++)
            {
                Vector3 result = Project(Polytope.Vertices[i].GlobalPosition);
                projectionPolyhedron.Vertices[i].LocalPosition = result;
            }
        }

        private Vector3 Project(Vector4 source)
        {
            Vector4 origin = new Vector4(
                   Polytope.Transform.Position.x,
                   Polytope.Transform.Position.y,
                   Polytope.Transform.Position.z,
                   Polytope.Transform.Position.w + ProjectionHeight
               );
            float x = source.x - source.w * ((origin.x - source.x) / (origin.w - source.w));
            float y = source.y - source.w * ((origin.y - source.y) / (origin.w - source.w));
            float z = source.z - source.w * ((origin.z - source.z) / (origin.w - source.w));

            return new Vector3(x, y, z);
        }
    }
}
