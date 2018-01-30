using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class GeneratedPolyhedron : Polyhedron
    {
        public GenerationFunction Generator;

        // Implement generation of Vertices and Edges in derived class
        protected override void GenerateVerticesAndEdges()
        {
            Generator(Vertices, Edges);
        }
    }
}
