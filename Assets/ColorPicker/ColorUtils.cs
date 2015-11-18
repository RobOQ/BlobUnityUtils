using UnityEngine;
using System.Collections;

public class ColorUtils
{
    /// <summary>
    /// Converts hue, saturation, and value into a UnityEngine.Color (RGB).  Assumes full alpha.
    /// Follows the approach on https://en.wikipedia.org/wiki/HSL_and_HSV
    /// </summary>
    /// <param name="hue">The hue in HSV in degrees [0-360)</param>
    /// <param name="saturation">The saturation in HSV, normalized on [0,1] </param>
    /// <param name="value">The value in HSV, normalized on [0,1]</param>
    /// <returns>The UnityEngine.Color (RGB) corresponding to the inputs, with full alpha.</returns>
    public static Color ConvertHSVToRGB(float hue, float saturation, float value)
    {
        // To ensure we have a value in [0,360)
        hue = MathUtil.NormalizeDegrees(hue);

        float chroma = value * saturation;

        float huePrime = hue / 60.0f;

        // x represents the second-largest component of this color
        float x = chroma * (1 - Mathf.Abs(huePrime % 2.0f - 1.0f));

        // Technically, (R, G, B) = (0, 0, 0) if H is undefined.  In our case, H cannot be undefined, so we ignore that case.

        Color result;

        if (0.0f <= huePrime && huePrime < 1.0f)
        {
            result = new Color(chroma, x, 0.0f);
        }
        else if (1.0f <= huePrime && huePrime < 2.0f)
        {
            result = new Color(x, chroma, 0.0f);
        }
        else if (2.0f <= huePrime && huePrime < 3.0f)
        {
            result = new Color(0.0f, chroma, x);
        }
        else if (3.0f <= huePrime && huePrime < 4.0f)
        {
            result = new Color(0.0f, x, chroma);
        }
        else if (4.0f <= huePrime && huePrime < 5.0f)
        {
            result = new Color(x, 0.0f, chroma);
        }
        else if (5.0f <= huePrime && huePrime < 6.0f)
        {
            result = new Color(chroma, 0.0f, x);
        }
        else
        {
            // Error case, return black
            Debug.LogError("huePrime was not in a valid range");
            result = Color.black;
        }

        float m = value - chroma;

        result.r += m;
        result.g += m;
        result.b += m;

        return result;
    }
}
