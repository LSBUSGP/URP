using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class MaterialUpdater
{
    static MaterialUpdater()
    {
        EditorApplication.playModeStateChanged += PlayModeStateChanged;
        EditorSceneManager.sceneOpened += SceneOpened;
        EditorSceneManager.sceneSaved += SceneSaved;
        EditorApplication.delayCall += UpdateSetMaterials;
        EditorApplication.hierarchyChanged += UpdateSetMaterials;
    }

    private static void SceneSaved(Scene scene)
    {
        UpdateSetMaterials();
    }

    private static void SceneOpened(Scene scene, OpenSceneMode mode)
    {
        UpdateSetMaterials();
    }

    private static void PlayModeStateChanged(PlayModeStateChange change)
    {
        if (change == PlayModeStateChange.EnteredEditMode)
        {
            UpdateSetMaterials();
        }
    }

    public static void UpdateSetMaterials()
    {
        foreach (var material in GameObject.FindObjectsOfType<SetBarsMaterial>())
        {
            material.SetMaterialProperties();
        }
    }
}
