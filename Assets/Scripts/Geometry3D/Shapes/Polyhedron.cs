using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry3D.Shapes
{
    public abstract class Polyhedron : MonoBehaviour
    {
        public Vertex3D[] Vertices;
        public Edge3D[] Edges;

        // Implement generation of Vertices and Edges in derived class
        protected abstract Vector3[] DefineVertexPositions();
        protected abstract Edge3D[] DefineEdges();

        // Run on script load
        public void Awake()
        {
            Vector3[] vertexPositions = DefineVertexPositions();
            SetVerticiesFromVectors(vertexPositions);
            Edges = DefineEdges();
        }

        private Vertex3D[] SetVerticiesFromVectors(Vector3[] vectors)
        {
            Vertices = new Vertex3D[vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                Vertices[i] = new Vertex3D(this, i, vectors[i]);
            }
            return Vertices;
        }

        // Creates a new GeneratedPolyhedron component attached to given object
        // Necessary because Unity's Monobehaviours can't really have proper constructors
        public static GeneratedPolyhedron GenerateFor(
            GameObject parent,
            GeneratedPolyhedron.VertexGenerator vertexGenerator,
            GeneratedPolyhedron.EdgeGenerator edgeGenerator
        )
        {
            // Pause parent to make sure Awake and Start run *after* initializing generators
            parent.SetActive(false);
            var polyhedron = parent.AddComponent<GeneratedPolyhedron>();
            polyhedron.VertexGeneratorFunction = vertexGenerator;
            polyhedron.EdgeGeneratorFunction = edgeGenerator;
            parent.SetActive(true);
            return polyhedron;
        }
    }
}
