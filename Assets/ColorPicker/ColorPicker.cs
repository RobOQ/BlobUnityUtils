using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour
{
    public float Left;
    public float Top;
    public float Width = 500;
    public float Height = 500;

    public int ColorPickerTextureWidth = 256;
    public int ColorPickerTextureHeight = 256;

    Texture2D colorPickerTexture;

    float currentHue;

    void Start()
    {
        currentHue = 0.0f;
        InitializeColorPickerTexture();
    }

    void OnGUI()
    {
        GUILayout.Window(0, new Rect(Left, Top, Width, Height), DrawColorPickerWindow, "Color Picker", GUILayout.Width(Width), GUILayout.Height(Height));
    }

    void DrawColorPickerWindow(int winId)
    {
        GUILayout.Box(colorPickerTexture, GUILayout.Width(ColorPickerTextureWidth), GUILayout.Height(ColorPickerTextureHeight));
    }

    void InitializeColorPickerTexture()
    {
        colorPickerTexture = new Texture2D(ColorPickerTextureWidth, ColorPickerTextureHeight);
        for (int satVal = 0; satVal < ColorPickerTextureWidth; ++satVal)
        {
            for (int vVal = 0; vVal < ColorPickerTextureHeight; ++vVal)
            {
                colorPickerTexture.SetPixel(satVal, vVal, ColorUtils.ConvertHSVToRGB(currentHue * 360.0f, (satVal / (float)ColorPickerTextureWidth), (vVal / (float)ColorPickerTextureHeight)));
            }
        }
        colorPickerTexture.Apply();
    }
}
