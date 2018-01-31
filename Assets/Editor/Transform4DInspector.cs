using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Scripts.Geometry4D;

[CustomEditor(typeof(Transform4D))]
class Transform4DInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var t = (Transform4D)target;
        float inputWidth = 50f;
        float labelWidth = 15f;
        float labelWidth2 = 25f;

        EditorGUILayout.LabelField("Position");
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("X", GUILayout.Width(labelWidth));
            t.Position.x = EditorGUILayout.FloatField(t.Position.x, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("Y", GUILayout.Width(labelWidth));
            t.Position.y = EditorGUILayout.FloatField(t.Position.y, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("Z", GUILayout.Width(labelWidth));
            t.Position.z = EditorGUILayout.FloatField(t.Position.z, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("W", GUILayout.Width(labelWidth));
            t.Position.w = EditorGUILayout.FloatField(t.Position.w, GUILayout.Width(inputWidth));
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.LabelField("Rotation");
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("XY", GUILayout.Width(labelWidth2));
            t.Rotation.XY = EditorGUILayout.FloatField(t.Rotation.XY, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("XZ", GUILayout.Width(labelWidth2));
            t.Rotation.XZ = EditorGUILayout.FloatField(t.Rotation.XZ, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("YZ", GUILayout.Width(labelWidth2));
            t.Rotation.YZ = EditorGUILayout.FloatField(t.Rotation.YZ, GUILayout.Width(inputWidth));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("XW", GUILayout.Width(labelWidth2));
            t.Rotation.XW = EditorGUILayout.FloatField(t.Rotation.XW, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("YW", GUILayout.Width(labelWidth2));
            t.Rotation.YW = EditorGUILayout.FloatField(t.Rotation.YW, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("ZW", GUILayout.Width(labelWidth2));
            t.Rotation.ZW = EditorGUILayout.FloatField(t.Rotation.ZW, GUILayout.Width(inputWidth));
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.LabelField("Scale");
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("X", GUILayout.Width(labelWidth));
            t.Scale.x = EditorGUILayout.FloatField(t.Scale.x, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("Y", GUILayout.Width(labelWidth));
            t.Scale.y = EditorGUILayout.FloatField(t.Scale.y, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("Z", GUILayout.Width(labelWidth));
            t.Scale.z = EditorGUILayout.FloatField(t.Scale.z, GUILayout.Width(inputWidth));

            EditorGUILayout.LabelField("W", GUILayout.Width(labelWidth));
            t.Scale.w = EditorGUILayout.FloatField(t.Scale.w, GUILayout.Width(inputWidth));
        EditorGUILayout.EndHorizontal();
    }
}
