using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D.Shapes
{
    public class FiveCell : Polytope4D
    {
        protected override Vector4[] DefineVertexPositions()
        {
            var vertexPositions = new Vector4[]
            {
                new Vector4(1f/Mathf.Sqrt(10f), 1f/Mathf.Sqrt(6f), 1f/Mathf.Sqrt(3f), 1f),
                new Vector4(1f/Mathf.Sqrt(10f), 1f/Mathf.Sqrt(6f), 1f/Mathf.Sqrt(3f), -1f),
                new Vector4(1f/Mathf.Sqrt(10f), 1f/Mathf.Sqrt(6f), -2f/Mathf.Sqrt(3f), 0),
                new Vector4(1f/Mathf.Sqrt(10f), -Mathf.Sqrt(1.5f), 0, 0),
                new Vector4(-2f * Mathf.Sqrt(0.4f), 0, 0, 0)
            };
            return vertexPositions;
        }

        protected override Edge4D[] DefineEdges()
        {
            var edges = new Edge4D[]
            {
                new Edge4D(Vertices[0], Vertices[1]),
                new Edge4D(Vertices[0], Vertices[2]),
                new Edge4D(Vertices[0], Vertices[3]),
                new Edge4D(Vertices[0], Vertices[4]),
                new Edge4D(Vertices[1], Vertices[2]),
                new Edge4D(Vertices[1], Vertices[3]),
                new Edge4D(Vertices[1], Vertices[4]),
                new Edge4D(Vertices[2], Vertices[3]),
                new Edge4D(Vertices[2], Vertices[4]),
                new Edge4D(Vertices[3], Vertices[4]),
            };
            return edges;
        }
    }
}
