using UnityEngine;

public class SetBarsMaterial : MonoBehaviour
{
    new public Renderer renderer;
    public Color[] colors = new Color[4];
    public float[] min = new float[4];
    public float[] max = new float[4];

    private void OnEnable()
    {
        SetMaterialProperties();
    }

    public void SetMaterialProperties()
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(block, 0);
        int length = colors.Length;
        if (length > 0)
        {
            Vector4[] vectors = new Vector4[length];
            for (int i = 0; i < length; ++i)
            {
                Color color = colors[i];
                vectors[i] = new Vector4(color.r, color.g, color.b, color.a);
            }
            block.SetVectorArray("_ColorArray", vectors);
            block.SetFloatArray("_MinArray", min);
            block.SetFloatArray("_MaxArray", max);
        }
        renderer.SetPropertyBlock(block, 0);
    }
}
