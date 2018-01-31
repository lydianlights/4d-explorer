using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Helpers;

namespace Scripts.Geometry3D.Shapes
{
    class Tetrahedron : Polyhedron
    {
        protected override Vector3[] DefineVertexPositions()
        {
            var vertexPositions = new Vector3[]
            {
                new Vector3(Mathf.Sqrt(8f/9f), -1f/3f, 0f),
                new Vector3(-Mathf.Sqrt(2f/9f), -1f/3f, Mathf.Sqrt(2f/3f)),
                new Vector3(-Mathf.Sqrt(2f/9f), -1f/3f, -Mathf.Sqrt(2f/3f)),
                new Vector3(0f, 1f, 0f),
            };
            return vertexPositions;
        }

        protected override Edge3D[] DefineEdges()
        {
            var edges = new Edge3D[]
            {
                new Edge3D(Vertices[0], Vertices[1]),
                new Edge3D(Vertices[0], Vertices[2]),
                new Edge3D(Vertices[0], Vertices[3]),
                new Edge3D(Vertices[1], Vertices[2]),
                new Edge3D(Vertices[1], Vertices[3]),
                new Edge3D(Vertices[2], Vertices[3]),
            };
            return edges;
        }
    }
}
