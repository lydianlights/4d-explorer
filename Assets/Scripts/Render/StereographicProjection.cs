using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes;

namespace Scripts.Render
{
    [RequireComponent(typeof(Polyhedron))]
    public class StereographicProjection : MonoBehaviour
    {
        public Polyhedron Polyhedron { get; private set; }

        // Run on script load
        public void Awake()
        {
            Polyhedron = GetComponent<Polyhedron>();
        }

        public void Start()
        {
            GenerateProjectionPolyhedron();
        }

        private void GenerateProjectionPolyhedron()
        {

        }
    }
}
