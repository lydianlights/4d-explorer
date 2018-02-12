using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Explorer4D.Geometry.Rendering;

[CustomEditor(typeof(RenderWireframe))]
class RenderWireframeInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Render"))
        {
            var t = (RenderWireframe)target;
            t.Awake();
            t.Polyhedron.Awake();
            t.Start();
        }
    }
}
