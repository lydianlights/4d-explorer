using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes4D
{
    public class Vertex4D
    {
        public Vector4 LocalPosition { get; set; }
        // TODO: Include rotations
        public Vector4 GlobalPosition
        {
            get
            {
                Vector4 result = LocalPosition;
                result.Scale(Parent.Transform.Scale);
                result = result + Parent.Transform.Position;
                return result;
            }
        }
        public int Index { get; set; }
        public Polytope4D Parent { get; private set; }

        public Vertex4D(Polytope4D parent, int index, Vector4 position)
        {
            Parent = parent;
            Index = index;
            LocalPosition = position;
        }

        public Vertex4D(Polytope4D parent, int index, float x, float y, float z, float w)
            : this(parent, index, new Vector4(x, y, z, w)) { }
    }
}
