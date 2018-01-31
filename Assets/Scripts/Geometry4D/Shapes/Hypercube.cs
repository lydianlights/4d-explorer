using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D.Shapes
{
    public class Hypercube : Polytope4D
    {
        protected override Vector4[] DefineVertexPositions()
        {
            var vertexPositions = new Vector4[]
            {
                new Vector4(0, 0, 0, 0),  new Vector4(1, 0, 0, 0),
                new Vector4(0, 0, 1, 0),  new Vector4(1, 0, 1, 0),

                new Vector4(0, 1, 0, 0),  new Vector4(1, 1, 0, 0),
                new Vector4(0, 1, 1, 0),  new Vector4(1, 1, 1, 0),

                new Vector4(0, 0, 0, 1),  new Vector4(1, 0, 0, 1),
                new Vector4(0, 0, 1, 1),  new Vector4(1, 0, 1, 1),

                new Vector4(0, 1, 0, 1),  new Vector4(1, 1, 0, 1),
                new Vector4(0, 1, 1, 1),  new Vector4(1, 1, 1, 1),
            };

            Vector4 offset = new Vector4(-0.5f, -0.5f, -0.5f, -0.5f);
            for (int i = 0; i < vertexPositions.Length; i++)
            {
                vertexPositions[i] += offset;
            }

            return vertexPositions;
        }

        protected override Edge4D[] DefineEdges()
        {
            var edges = new Edge4D[32];

            // Edge 0 - 15
            for (int i = 0; i < 4; i++)
            {
                edges[4 * i + 0] = new Edge4D(Vertices[0 + 4 * i], Vertices[1 + 4 * i]);
                edges[4 * i + 1] = new Edge4D(Vertices[1 + 4 * i], Vertices[3 + 4 * i]);
                edges[4 * i + 2] = new Edge4D(Vertices[3 + 4 * i], Vertices[2 + 4 * i]);
                edges[4 * i + 3] = new Edge4D(Vertices[2 + 4 * i], Vertices[0 + 4 * i]);

                // Edge 16 - 23
                edges[16 + i] = new Edge4D(Vertices[i + 0], Vertices[i + 4]);
                edges[20 + i] = new Edge4D(Vertices[i + 8 + 0], Vertices[i + 8 + 4]);
            }

            for (int i = 0; i < 8; i++)
            {
                // Edge 24 - 31
                edges[24 + i] = new Edge4D(Vertices[i], Vertices[i + 8]);
            }

            return edges;
        }
    }
}
