using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex[] Vertices { get; protected set; }
        public Edge[] Edges { get; protected set; }

        // Implement generation of Vertices and Edges in derived class
        protected abstract void GenerateVerticesAndEdges();

        // Set by Unity
        public float FrameThickness = 0.05f;

        // Run on script load
        protected void Awake()
        {

        }

        // Run on object load
        protected void Start()
        {
            GenerateVerticesAndEdges();
            RenderWireframe();
        }

        protected void RenderWireframe()
        {
            // Generate sphere at each vertex
            foreach (Vertex vertex in Vertices)
            {
                float sphereRadius = FrameThickness;
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.SetParent(gameObject.transform);
                sphere.transform.localPosition = vertex.Position;
                sphere.transform.localScale = new Vector3(sphereRadius, sphereRadius, sphereRadius);
            }

            // Generate frame connecting vertices with edges
            foreach (Edge edge in Edges)
            {
                Vertex vtxA = edge.Endpoints[0];
                Vertex vtxB = edge.Endpoints[1];
                Vector3 offest = vtxA.Position - vtxB.Position;

                GameObject edgeObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                edgeObj.transform.SetParent(gameObject.transform);
                edgeObj.transform.localPosition = vtxA.Position - offest / 2;
                edgeObj.transform.LookAt(gameObject.transform.position + vtxB.Position);
                edgeObj.transform.Rotate(90, 0, 0);
                edgeObj.transform.localScale = new Vector3(FrameThickness, offest.magnitude / 2, FrameThickness);
            }
        }
    }
}
