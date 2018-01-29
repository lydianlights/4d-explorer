using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Edge
    {
        public Vertex[] Endpoints { get; }

        public Edge(Vertex a, Vertex b)
        {
            Endpoints = new Vertex[2] { a, b };
        }
    }
}
