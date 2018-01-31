using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes4D
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
            }

            // Edge 16 - 23
            // Encoding this in a for loop would be longer than just writing it...
            edges[16] = new Edge4D(Vertices[0], Vertices[2]);
            edges[17] = new Edge4D(Vertices[1], Vertices[3]);
            edges[18] = new Edge4D(Vertices[4], Vertices[6]);
            edges[19] = new Edge4D(Vertices[5], Vertices[7]);

            edges[20] = new Edge4D(Vertices[8], Vertices[10]);
            edges[21] = new Edge4D(Vertices[9], Vertices[11]);
            edges[22] = new Edge4D(Vertices[12], Vertices[14]);
            edges[23] = new Edge4D(Vertices[13], Vertices[15]);

            // Edge 24 - 31
            for (int i = 0; i < 8; i++)
            {
                edges[24 + i] = new Edge4D(Vertices[i], Vertices[i + 8]);
            }

            return edges;
        }
    }
}
