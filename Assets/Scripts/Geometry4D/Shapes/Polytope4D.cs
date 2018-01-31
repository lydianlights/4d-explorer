using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D.Shapes
{
    [RequireComponent(typeof(Transform4D))]
    public abstract class Polytope4D : MonoBehaviour
    {
        [NonSerialized]
        public Transform4D Transform;

        public Vertex4D[] Vertices;
        public Edge4D[] Edges;

        // Implement generation of Vertices and Edges in derived class
        protected abstract Vector4[] DefineVertexPositions();
        protected abstract Edge4D[] DefineEdges();

        // Run on script load
        public void Awake()
        {
            Transform = GetComponent<Transform4D>();
            Vector4[] vertexPositions = DefineVertexPositions();
            SetVerticiesFromVectors(vertexPositions);
            Edges = DefineEdges();
        }

        private Vertex4D[] SetVerticiesFromVectors(Vector4[] vectors)
        {
            Vertices = new Vertex4D[vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                Vertices[i] = new Vertex4D(this, i, vectors[i]);
            }
            return Vertices;
        }
    }
}
