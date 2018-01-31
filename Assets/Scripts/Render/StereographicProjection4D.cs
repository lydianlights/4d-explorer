﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes3D;
using Scripts.Shapes4D;
using Scripts.Debugging;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polytope4D))]
    public class StereographicProjection4D : MonoBehaviour
    {
        public Polytope4D Polytope { get; private set; }

        private GeneratedPolyhedron projectionPolyhedron;
        private GameObject projectionObj;

        // Run on script load
        public void Awake()
        {
            Polytope = GetComponent<Polytope4D>();
        }

        // Run on object load
        public void Start()
        {
            GenerateProjection();
        }

        private void GenerateProjection()
        {
            DestroyImmediate(projectionObj);
            projectionObj = new GameObject("Stereographic Projection");
            projectionObj.transform.SetParent(gameObject.transform);

            // TODO: Use vertex global position that will be defined by the polytope's Transform4D
            projectionPolyhedron = Polyhedron.GenerateFor(
                projectionObj,
                (self) =>
                {
                    var vertexPositions = new Vector3[Polytope.Vertices.Length];
                    for (int i = 0; i < vertexPositions.Length; i++)
                    {
                        vertexPositions[i] = Project(Polytope.Vertices[i].LocalPosition);
                    }
                    return vertexPositions;
                },
                (self) =>
                {
                    var edges = new Edge3D[Polytope.Edges.Length];
                    for (int i = 0; i < edges.Length; i++)
                    {
                        int indexA = Polytope.Edges[i].Endpoints[0].Index;
                        int indexB = Polytope.Edges[i].Endpoints[1].Index;
                        edges[i] = new Edge3D(self.Vertices[indexA], self.Vertices[indexB]);
                    }
                    return edges;
                }
            );

            projectionObj.AddComponent<RenderWireframe>();
            projectionObj.AddComponent<LogVertices3D>();
            projectionObj.AddComponent<LogEdges3D>();
        }

        public static Vector3 Project(Vector4 source)
        {
            return new Vector3(source.x, source.y, source.z);
        }
    }
}
