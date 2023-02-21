using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(SetBarsMaterial))]
[CanEditMultipleObjects]
public class EditBarsMaterial : Editor
{
    SerializedProperty colorArray;
    SerializedProperty minArray;
    SerializedProperty maxArray;

    private void OnEnable()
    {
        colorArray = serializedObject.FindProperty("colors");
        minArray = serializedObject.FindProperty("min");
        maxArray = serializedObject.FindProperty("max");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(colorArray);
        EditorGUILayout.PropertyField(minArray);
        EditorGUILayout.PropertyField(maxArray);
        if (serializedObject.hasModifiedProperties)
        {
            serializedObject.ApplyModifiedProperties();
            foreach (var target in serializedObject.targetObjects)
            {
                (target as SetBarsMaterial).SetMaterial();
            }
        }
    }
}
