using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Helpers;

namespace Scripts.Shapes
{
    class Tetrahedron : Polyhedron
    {
        protected override void GenerateVerticesAndEdges()
        {
            var vertexPositions = new Vector3[]
            {
                new Vector3(Mathf.Sqrt(8f/9f), -1f/3f, 0f),
                new Vector3(-Mathf.Sqrt(2f/9f), -1f/3f, Mathf.Sqrt(2f/3f)),
                new Vector3(-Mathf.Sqrt(2f/9f), -1f/3f, -Mathf.Sqrt(2f/3f)),
                new Vector3(0f, 1f, 0f),
            };

            SetVerticiesFromVectors(vertexPositions);

            Edges = new Edge[]
            {
                new Edge(Vertices[0], Vertices[1]),
                new Edge(Vertices[0], Vertices[2]),
                new Edge(Vertices[0], Vertices[3]),
                new Edge(Vertices[1], Vertices[2]),
                new Edge(Vertices[1], Vertices[3]),
                new Edge(Vertices[2], Vertices[3]),
            };
        }
    }
}
