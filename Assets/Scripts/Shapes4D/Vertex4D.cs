using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes4D
{
    public class Vertex4D
    {
        public Vector4 LocalPostion { get; set; }

        // TODO: Global Position
        public int Index { get; set; }
        public Polytope4D Parent { get; private set; }

        public Vertex4D(Polytope4D parent, int index, Vector4 position)
        {
            Parent = parent;
            Index = index;
            LocalPostion = position;
        }

        public Vertex4D(Polytope4D parent, int index, float x, float y, float z, float w)
            : this(parent, index, new Vector4(x, y, z, w)) { }
    }
}
