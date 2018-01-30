using System;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Shapes4D;

namespace Scripts.Shapes4D
{
    [RequireComponent(typeof(Transform4D))]
    public class Polytope4D : MonoBehaviour
    {
        [NonSerialized]
        public Transform4D Transform;

        // Run on script load
        public void Awake()
        {
            Transform = GetComponent<Transform4D>();
        }
    }
}
