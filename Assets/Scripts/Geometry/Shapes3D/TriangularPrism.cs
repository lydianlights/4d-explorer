using System;
using System.Collections.Generic;
using UnityEngine;

namespace Explorer4D.Geometry.Shapes3D
{
    public class TriangularPrism : Polyhedron
    {
        public float Length = 1;

        protected override Vector3[] DefineVertexPositions()
        {
            float yOffset = Length / 2;
            var vertexPositions = new Vector3[]
            {
                new Vector3(-MathHelpers.Sqrt3Inv, -yOffset, -1f/3f),
                new Vector3(MathHelpers.Sqrt3Inv, -yOffset, -1f/3f),
                new Vector3(0, -yOffset, 2f/3f),

                new Vector3(-MathHelpers.Sqrt3Inv, yOffset, -1f/3f),
                new Vector3(MathHelpers.Sqrt3Inv, yOffset, -1f/3f),
                new Vector3(0, yOffset, 2f/3f),
            };
            return vertexPositions;
        }

        protected override Edge3D[] DefineEdges()
        {
            var edges = new Edge3D[]
            {
                new Edge3D(Vertices[0], Vertices[1]),
                new Edge3D(Vertices[1], Vertices[2]),
                new Edge3D(Vertices[2], Vertices[0]),

                new Edge3D(Vertices[0], Vertices[3]),
                new Edge3D(Vertices[1], Vertices[4]),
                new Edge3D(Vertices[2], Vertices[5]),

                new Edge3D(Vertices[3], Vertices[4]),
                new Edge3D(Vertices[4], Vertices[5]),
                new Edge3D(Vertices[5], Vertices[3]),
            };
            return edges;
        }
    }
}
