using System;
using System.Collections.Generic;
using UnityEngine;

namespace Explorer4D.Geometry
{
    public class Edge4D
    {
        public Vertex4D[] Endpoints { get; private set; }

        public Edge4D(Vertex4D a, Vertex4D b)
        {
            Endpoints = new Vertex4D[2] { a, b };
        }
    }
}
