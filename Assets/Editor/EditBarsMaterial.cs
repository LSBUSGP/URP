using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(SetBarsMaterial))]
[CanEditMultipleObjects]
public class EditBarsMaterial : Editor
{
    SerializedProperty renderer;
    SerializedProperty colorArray;
    SerializedProperty minArray;
    SerializedProperty maxArray;

    private void OnEnable()
    {
        renderer = serializedObject.FindProperty("renderer");
        colorArray = serializedObject.FindProperty("colors");
        minArray = serializedObject.FindProperty("min");
        maxArray = serializedObject.FindProperty("max");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(renderer);
        EditorGUILayout.PropertyField(colorArray);
        EditorGUILayout.PropertyField(minArray);
        EditorGUILayout.PropertyField(maxArray);
        if (serializedObject.hasModifiedProperties)
        {
            serializedObject.ApplyModifiedProperties();
            EditorApplication.delayCall += MaterialUpdater.UpdateSetMaterials;
        }
    }
}
