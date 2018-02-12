using System;
using System.Collections.Generic;
using UnityEngine;
using Explorer4D.Geometry.Shapes4D;

namespace Explorer4D.Geometry.Behaviors
{
    [RequireComponent(typeof(Polytope4D))]
    class TestRotatePolytope4D : MonoBehaviour
    {
        // Set by Unity
        public float XYSpeed = 0;
        public float XZSpeed = 0;
        public float YZSpeed = 0;
        public float XWSpeed = 0;
        public float YWSpeed = 0;
        public float ZWSpeed = 0;

        private Polytope4D polytope;

        // Run on script load
        public void Awake()
        {
            polytope = GetComponent<Polytope4D>();
        }

        public void FixedUpdate()
        {
            polytope.Transform.Rotation.XY += XYSpeed * Time.deltaTime;
            polytope.Transform.Rotation.XZ += XZSpeed * Time.deltaTime;
            polytope.Transform.Rotation.YZ += YZSpeed * Time.deltaTime;
            polytope.Transform.Rotation.XW += XWSpeed * Time.deltaTime;
            polytope.Transform.Rotation.YW += YWSpeed * Time.deltaTime;
            polytope.Transform.Rotation.ZW += ZWSpeed * Time.deltaTime;
        }
    }
}
