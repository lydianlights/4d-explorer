using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes;

namespace Scripts
{
    public class Vertex
    {
        public Vector3 LocalPosition { get; set; }
        // TODO: Setter for global position
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
        public int Index { get; set; }
        public Polyhedron Parent { get; private set; }

        public Vertex(Polyhedron parent, int index, Vector3 position)
        {
            Parent = parent;
            Index = index;
            LocalPosition = position;
        }

        public Vertex(Polyhedron parent, int index, float x, float y, float z)
            : this(parent, index, new Vector3(x, y, z)) { }
    }
}