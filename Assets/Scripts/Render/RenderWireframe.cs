using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polyhedron))]
    public class RenderWireframe : MonoBehaviour
    {
        // Set by Unity
        public float FrameThickness = 0.05f;

        public Polyhedron Polyhedron { get; private set; }

        private GameObject wireframe;

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        // Run on object load
        public void Start()
        {
            Render();
        }

        private void Render()
        {
            // Create wireframe gameobject to hold frame info
            DestroyImmediate(wireframe);
            wireframe = new GameObject("Wireframe");
            wireframe.transform.SetParent(gameObject.transform);

            // Generate sphere at each vertex
            foreach (Vertex vertex in Polyhedron.Vertices)
            {
                float sphereRadius = FrameThickness;
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.SetParent(wireframe.transform);
                sphere.transform.localPosition = vertex.Position;
                sphere.transform.localScale = new Vector3(sphereRadius, sphereRadius, sphereRadius);
            }

            // Generate frame connecting vertices with edges
            foreach (Edge edge in Polyhedron.Edges)
            {
                Vertex vtxA = edge.Endpoints[0];
                Vertex vtxB = edge.Endpoints[1];
                Vector3 offset = vtxA.Position - vtxB.Position;

                GameObject edgeObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                edgeObj.transform.SetParent(wireframe.transform);
				edgeObj.transform.localPosition = vtxA.Position - offset / 2;
                edgeObj.transform.localScale = new Vector3(FrameThickness, offset.magnitude / 2, FrameThickness);
                edgeObj.transform.localRotation = Quaternion.LookRotation(offset);
				edgeObj.transform.Rotate(90, 0, 0);
            }

            // Transform wireframe to parent's position
            wireframe.transform.localPosition = Vector3.zero;
            wireframe.transform.localEulerAngles = Vector3.zero;
            wireframe.transform.localScale = Vector3.one;
        }
    }
}
