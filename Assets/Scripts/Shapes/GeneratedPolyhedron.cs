using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes
{
    public class GeneratedPolyhedron : Polyhedron
    {
        public GenerationFunction Generator;
        
        protected override void GenerateVerticesAndEdges()
        {
            Generator(Vertices, Edges);
        }
    }
}
