using System;
using System.Collections.Generic;
using UnityEngine;

namespace Explorer4D.Geometry.Shapes4D
{
    public class Poly16Cell : Polytope4D
    {
        protected override Vector4[] DefineVertexPositions()
        {
            var vertexPositions = new Vector4[]
            {
                new Vector4(1, 0, 0, 0), new Vector4(-1, 0, 0, 0),
                new Vector4(0, 1, 0, 0), new Vector4(0, -1, 0, 0),
                new Vector4(0, 0, 1, 0), new Vector4(0, 0, -1, 0),
                new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, -1),
            };
            return vertexPositions;
        }

        protected override Edge4D[] DefineEdges()
        {
            var edges = new Edge4D[24];

            int currEdge = 0;
            for (int i = 0; i < 6; i += 2)
            {
                for (int j = i + 2; j < 8; j++)
                {
                    edges[currEdge] = new Edge4D(Vertices[i], Vertices[j]);
                    edges[currEdge + 1] = new Edge4D(Vertices[i + 1], Vertices[j]);
                    currEdge += 2;
                }
            }

            return edges;
        }
    }
}
