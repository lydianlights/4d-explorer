using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes3D
{
    public class GeneratedPolyhedron : Polyhedron
    {
        public delegate void GenerationFunction(Polyhedron self, ref Vertex3D[] vertices, ref Edge3D[] edges);
        public GenerationFunction Generator;

        protected override void GenerateVerticesAndEdges()
        {
            Generator(this, ref Vertices, ref Edges);
        }
    }
}
