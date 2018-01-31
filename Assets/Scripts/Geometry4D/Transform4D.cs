using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Geometry4D
{
    public class Transform4D : MonoBehaviour
    {
        // TODO: Rotations
        public Vector4 Position = new Vector4(0, 0, 0, 0);
        public Orientation4D Rotation = new Orientation4D();
        public Vector4 Scale = new Vector4(1, 1, 1, 1);
    }
}
