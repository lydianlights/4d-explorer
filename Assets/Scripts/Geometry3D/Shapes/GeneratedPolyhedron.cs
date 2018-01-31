using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry3D.Shapes
{
    public class GeneratedPolyhedron : Polyhedron
    {
        public delegate Vector3[] VertexGenerator(GeneratedPolyhedron self);
        public delegate Edge3D[] EdgeGenerator(GeneratedPolyhedron self);

        public VertexGenerator VertexGeneratorFunction = null;
        public EdgeGenerator EdgeGeneratorFunction = null;

        // TODO: Do some error checking in case generators are never definied
        protected override Vector3[] DefineVertexPositions()
        {
            return VertexGeneratorFunction(this);
        }

        protected override Edge3D[] DefineEdges()
        {
            return EdgeGeneratorFunction(this);
        }
    }
}
