using System;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
