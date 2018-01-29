using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex[] Vertices { get; protected set; }
        public Edge[] Edges { get; protected set; }

        // Implement generation of Vertices and Edges in derived class
        protected abstract void GenerateVerticesAndEdges();

        // Run on script load
        public void Awake()
        {
            GenerateVerticesAndEdges();
        }
    }
}
