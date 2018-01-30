using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes3D
{
    // TODO: Refactor Polyhedron generation to be a little less obtuse
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex3D[] Vertices = new Vertex3D[] { };
        public Edge3D[] Edges = new Edge3D[] { };

        // Implement generation of Vertices and Edges in derived class
        protected abstract void GenerateVerticesAndEdges();

        // Run on script load
        public void Awake()
        {
            GenerateVerticesAndEdges();
        }

        public Vertex3D[] SetVerticiesFromVectors(Vector3[] vectors)
        {
            Vertices = new Vertex3D[vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                Vertices[i] = new Vertex3D(this, i, vectors[i]);
            }
            return Vertices;
        }

        public static GeneratedPolyhedron GenerateFor(GameObject parent, GeneratedPolyhedron.GenerationFunction generator)
        {
            parent.SetActive(false);
            var polyhedron = parent.AddComponent<GeneratedPolyhedron>();
            polyhedron.Generator = generator;
            parent.SetActive(true);
            return polyhedron;
        }
    }
}
