using System;
using System.Collections.Generic;
using UnityEngine;
using Explorer4D.Geometry.Shapes4D;

namespace Explorer4D.Geometry
{
    public class Vertex4D
    {
        public Vector4 LocalPosition { get; set; }
        // TODO: Setter for global position
        public Vector4 GlobalPosition
        {
            get
            {
                Vector4 result = Parent.Transform.Rotation.TransformVector(LocalPosition);
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
