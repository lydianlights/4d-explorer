using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes3D
{
    public class GeneratedPolyhedron : Polyhedron
    {
        public GenerationFunction Generator;
        
        protected override void GenerateVerticesAndEdges()
        {
            Generator(this, ref Vertices, ref Edges);
        }
    }
}
