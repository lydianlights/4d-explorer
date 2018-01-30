using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes
{
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex[] Vertices { get; protected set; }
        public Edge[] Edges { get; protected set; }

        // Implement generation of Vertices and Edges in derived class
        protected abstract void GenerateVerticesAndEdges();

        public delegate void GenerationFunction(Vertex[] vertices, Edge[] edges);

        // Run on script load
        public void Awake()
        {
            GenerateVerticesAndEdges();
        }

        public static void GenerateFor(GameObject parent, GenerationFunction generator)
        {
            parent.SetActive(false);
            var polyhedron = parent.AddComponent<GeneratedPolyhedron>();
            polyhedron.Generator = generator;
            parent.SetActive(true);
        }
    }
}
