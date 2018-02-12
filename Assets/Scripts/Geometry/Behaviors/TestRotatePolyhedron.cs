using System;
using System.Collections.Generic;
using UnityEngine;
using Explorer4D.Geometry.Shapes3D;

namespace Explorer4D.Geometry.Behaviors
{
    [RequireComponent(typeof(Polyhedron))]
    public class TestRotatePolyhedron : MonoBehaviour
    {
        // Set by Unity
        public float XSpeed = 0;
        public float YSpeed = 30;
        public float ZSpeed = 0;

        public Polyhedron Polyhedron { get; private set; }

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        // Run every frame
        public void FixedUpdate()
        {
            var sinY = Mathf.Sin(Mathf.Deg2Rad * YSpeed * Time.fixedDeltaTime);
            var cosY = Mathf.Cos(Mathf.Deg2Rad * YSpeed * Time.fixedDeltaTime);

            foreach (Vertex3D vertex in Polyhedron.Vertices)
            {
                var v = vertex.LocalPosition;
                var x = v.x * cosY + v.z * sinY;
                var y = v.y;
                var z = -v.x * sinY + v.z * cosY;
                vertex.LocalPosition = new Vector3(x, y, z);
            }
        }
    }
}
