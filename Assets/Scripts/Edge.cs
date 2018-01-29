using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Edge
    {
        public Vertex[] Endpoints { get; private set; }

        public Edge(Vertex a, Vertex b)
        {
            Endpoints = new Vertex[2] { a, b };
        }
    }
}
