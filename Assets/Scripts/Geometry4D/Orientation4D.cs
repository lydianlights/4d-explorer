using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D
{
    // TODO: Do some fancy math because 6 planes of rotation is redundant... but easy to think about
    public class Orientation4D
    {
        public float XY = 0;
        public float XZ = 0;
        public float YZ = 0;
        public float XW = 0;
        public float YW = 0;
        public float ZW = 0;

        public Orientation4D() { }

        public Orientation4D(float xy, float xz, float yz, float xw, float yw, float zw)
        {
            XY = xy;
            XZ = xz;
            YZ = yz;
            XW = xw;
            YW = yw;
            ZW = zw;
        }

        // TODO: Test only rotates about xw plane
        public Vector4 TransformVector(Vector4 source)
        {
            var sinA = Mathf.Sin(Mathf.Deg2Rad * XW);
            var cosA = Mathf.Cos(Mathf.Deg2Rad * XW);
            var x = source.x * cosA - source.w * sinA;
            var y = source.y;
            var z = source.z;
            var w = source.w * cosA + source.y * sinA;
            return new Vector4(x, y, z, w);
        }
    }
}
