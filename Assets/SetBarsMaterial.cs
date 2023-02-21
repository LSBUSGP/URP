using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBarsMaterial : MonoBehaviour
{
    public Color[] colors = new Color[4];
    public float[] min = new float[4];
    public float[] max = new float[4];

    Material material;

    private void Awake()
    {
        InitializeMaterialInstance();
    }

    private void InitializeMaterialInstance()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = new Material(renderer.sharedMaterial);
        renderer.material = material;
        SetMaterial();
    }

    private void OnValidate()
    {
        Debug.Log("OnValidate");

        InitializeMaterialInstance();
    }

    public void SetMaterial()
    {
        material.SetColorArray("_ColorArray", colors);
        material.SetFloatArray("_MinArray", min);
        material.SetFloatArray("_MaxArray", max);
    }
}
