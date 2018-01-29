using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Vertex
    {
        public Vector3 Position { get; set; }

        public Vertex(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
        }

        public Vertex(Vector3 position)
        {
            Position = position;
        }
    }
}