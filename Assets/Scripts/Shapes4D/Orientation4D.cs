using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Shapes4D
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
    }
}
