using UnityEngine;
using System.Collections;

public class MathUtil
{
    public static float NormalizeDegrees(float degrees)
    {
        while (degrees < 0.0f)
        {
            degrees += 360.0f;
        }

        while (degrees >= 360.0f)
        {
            degrees -= 360.0f;
        }

        return degrees;
    }
}
