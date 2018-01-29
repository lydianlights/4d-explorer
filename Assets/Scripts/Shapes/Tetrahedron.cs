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
            Vertices = new Vertex[]
            {
                new Vertex(this, Mathf.Sqrt(8f/9f), -1f/3f, 0f),
                new Vertex(this, -Mathf.Sqrt(2f/9f), -1f/3f, Mathf.Sqrt(2f/3f)),
                new Vertex(this, -Mathf.Sqrt(2f/9f), -1f/3f, -Mathf.Sqrt(2f/3f)),
                new Vertex(this, 0f, 1f, 0f),
            };

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
