using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes
{
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex[] Vertices = new Vertex[] { };
        public Edge[] Edges = new Edge[] { };

        // Implement generation of Vertices and Edges in derived class
        protected abstract void GenerateVerticesAndEdges();

        public delegate void GenerationFunction(Polyhedron self, ref Vertex[] vertices, ref Edge[] edges);

        // Run on script load
        public void Awake()
        {
            GenerateVerticesAndEdges();
        }

        public static GeneratedPolyhedron GenerateFor(GameObject parent, GenerationFunction generator)
        {
            parent.SetActive(false);
            var polyhedron = parent.AddComponent<GeneratedPolyhedron>();
            polyhedron.Generator = generator;
            parent.SetActive(true);
            return polyhedron;
        }
    }
}
