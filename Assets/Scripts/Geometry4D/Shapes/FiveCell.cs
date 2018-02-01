using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Helpers;

namespace Scripts.Geometry4D.Shapes
{
    public class FiveCell : Polytope4D
    {
        protected override Vector4[] DefineVertexPositions()
        {
            var vertexPositions = new Vector4[]
            {
                new Vector4(1f, 1f, 1f, -MathHelpers.Sqrt5Inv),
                new Vector4(1f, -1f, -1f, -MathHelpers.Sqrt5Inv),
                new Vector4(-1f, 1f, -1f, -MathHelpers.Sqrt5Inv),
                new Vector4(-1f, -1f, 1f, -MathHelpers.Sqrt5Inv),
                new Vector4(0f, 0f, 0f, MathHelpers.Sqrt5 - MathHelpers.Sqrt5Inv),
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
