using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polyhedron))]
    public class RenderWireframe : MonoBehaviour
    {
        // Set by Unity
        public float FrameThickness = 0.05f;

        public Polyhedron Polyhedron { get; private set; }

        private GameObject wireframe;
        private GameObject[] vertexSpheres;
        private GameObject[] edgeConnections;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        // Run on object load
        public void Start()
        {
            GenerateFrameObjects();
            UpdateFrameObjects();
        }

        // Run each frame
        public void Update()
        {
            //UpdateFrameObjects();
        }

        public void GenerateFrameObjects()
        {
            // Create wireframe gameobject to hold frame info
            DestroyImmediate(wireframe);
            wireframe = new GameObject("Wireframe");
            wireframe.transform.SetParent(gameObject.transform);

            // Generate sphere for each vertex
            vertexSpheres = new GameObject[Polyhedron.Vertices.Length];
            for (int i = 0; i < vertexSpheres.Length; i++)
            {
                vertexSpheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                vertexSpheres[i].transform.SetParent(wireframe.transform);
            }

            // Generate edge connection for each edge
            edgeConnections = new GameObject[Polyhedron.Edges.Length];
            for (int j = 0; j < edgeConnections.Length; j++)
            {
                edgeConnections[j] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                edgeConnections[j].transform.SetParent(wireframe.transform);
            }

            // Transform wireframe to parent's position
            wireframe.transform.localPosition = Vector3.zero;
            wireframe.transform.localEulerAngles = Vector3.zero;
            wireframe.transform.localScale = Vector3.one;
        }

        private void UpdateFrameObjects()
        {
            for (int i = 0; i < vertexSpheres.Length; i++)
            {
                float sphereRadius = FrameThickness;
                vertexSpheres[i].transform.localPosition = Polyhedron.Vertices[i].LocalPosition;
                vertexSpheres[i].transform.localScale = sphereRadius * Vector3.one;
            }

            for (int j = 0; j < edgeConnections.Length; j++)
            {
                Vertex vtxA = Polyhedron.Edges[j].Endpoints[0];
                Vertex vtxB = Polyhedron.Edges[j].Endpoints[1];
                Vector3 offset = vtxA.LocalPosition - vtxB.LocalPosition;
                
                edgeConnections[j].transform.localPosition = vtxA.LocalPosition - offset / 2;
                edgeConnections[j].transform.localScale = new Vector3(FrameThickness, offset.magnitude / 2, FrameThickness);
                edgeConnections[j].transform.localRotation = Quaternion.LookRotation(offset);
                edgeConnections[j].transform.Rotate(90, 0, 0);
            }
        }
    }
}
