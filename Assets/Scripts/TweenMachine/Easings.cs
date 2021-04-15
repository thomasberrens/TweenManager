using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Easings
{
    public static float Linear(float x)
    {
        return x;
    }
    public static float EaseInQuad(float x)
    {
        return x * x;
    }

    public static float EaseInCubic(float x)
    {
        return x * x * x;
    }

    public static float EaseInQuart(float x)
    {
        return x * x * x * x;
    }
    
    public static float EaseInQuint(float x)
    {
        return x * x * x * x * x;
    }

    public static float EaseInBack(float x)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;

        return c3 * x * x * x - c1 * x * x;
    }
}
