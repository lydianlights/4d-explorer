using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vertex
    {
        public Vector3 Position { get; }

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