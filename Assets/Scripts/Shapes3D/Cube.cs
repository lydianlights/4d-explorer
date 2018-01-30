﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes3D
{
    class Cube : Polyhedron
    {
        protected override void GenerateVerticesAndEdges()
        {
            var vertexPositions = new Vector3[]
            {
                new Vector3(0, 0, 0), new Vector3(1, 0, 0),
                new Vector3(0, 0, 1), new Vector3(1, 0, 1),

                new Vector3(0, 1, 0), new Vector3(1, 1, 0),
                new Vector3(0, 1, 1), new Vector3(1, 1, 1),
            };

            SetVerticiesFromVectors(vertexPositions);

            Edges = new Edge3D[]
            {
                new Edge3D(Vertices[0], Vertices[4]),
                new Edge3D(Vertices[4], Vertices[6]),
                new Edge3D(Vertices[6], Vertices[2]),
                new Edge3D(Vertices[2], Vertices[0]),

                new Edge3D(Vertices[4], Vertices[5]),
                new Edge3D(Vertices[6], Vertices[7]),
                new Edge3D(Vertices[2], Vertices[3]),
                new Edge3D(Vertices[0], Vertices[1]),

                new Edge3D(Vertices[1], Vertices[5]),
                new Edge3D(Vertices[5], Vertices[7]),
                new Edge3D(Vertices[7], Vertices[3]),
                new Edge3D(Vertices[3], Vertices[1]),
            };

            Vector3 offset = new Vector3(0.5f, 0.5f, 0.5f);
            foreach (Vertex3D vertex in Vertices)
            {
                vertex.LocalPosition -= offset;
            }
        }
    }
}
