using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D.Shapes
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
            
            return edges;
        }
    }
}
