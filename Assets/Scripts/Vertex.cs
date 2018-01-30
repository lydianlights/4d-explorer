using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes;

namespace Scripts
{
    public class Vertex
    {
        public Vector3 LocalPosition { get; set; }
        public Vector3 GlobalPosition
        {
            get
            {
                Vector3 result = Parent.transform.rotation * LocalPosition;
                result.Scale(Parent.transform.localScale);
                result = result + Parent.transform.position;
                return result;
            }
        }
        public Polyhedron Parent { get; private set; }

        public Vertex(Polyhedron parent, float x, float y, float z)
        {
            Parent = parent;
            LocalPosition = new Vector3(x, y, z);
        }

        public Vertex(Polyhedron parent, Vector3 position)
        {
            Parent = parent;
            LocalPosition = position;
        }
    }
}