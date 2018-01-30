using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes3D
{
    public class Edge3D
    {
        public Vertex3D[] Endpoints { get; private set; }

        public Edge3D(Vertex3D a, Vertex3D b)
        {
            Endpoints = new Vertex3D[2] { a, b };
        }
    }
}
