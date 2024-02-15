
using UnityEditor;
using System;

[System.Serializable]
public struct Utils
{
    // Radians to degrees constant

    public const float Rad2Deg = 57.29578f;

    //Min max between 2 values

    public static int Min(int a, int b)
    {
        return (a < b) ? a : b;
    }

    public static int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }
    public static float Min(float a, float b)
    {
        return (a < b) ? a : b;
    }

    public static float Max(float a, float b)
    {
        return (a > b) ? a : b;
    }

    public static int Clamp(int value, int min, int max)
    {
        if (value < min) { value = min; }
        else if (value > max) { value = max; }
        return value;
    }

    public static float Clamp(float value, float min, float max)
    {
        if (value < min) { value = min; }
        else if (value > max) { value = max; }
        return value;
    }

    public static float Clamp01(float value)
    {
        if(value < 0.0f)
        {
            return 0.0f;
        }
        else if (value > 1.0f)
        {
            return 1.0f;
        }
        return value;
    }

    public static float Lerp(float a, float b, float t)
    {
        return a + (b - a) * Clamp01(t);
    }

    public static float LerpUnclamped(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    public static float MoveTowards(float current, float target, float maxDelta)
    {
        if (Math.Abs(target - current) <= maxDelta)
        {
            return target;
        }

        return current + Math.Sign(target - current) * maxDelta;
    }


    internal static bool LineIntersection(Vector3C p1, Vector3C p2, Vector3C p3, Vector3C p4, ref Vector3C result)
    {
        float num = p2.x - p1.x;
        float num2 = p2.y - p1.y;
        float num3 = p4.x - p3.x;
        float num4 = p4.y - p3.y;
        float num5 = num * num4 - num2 * num3;
        if (num5 == 0f)
        {
            return false;
        }

        float num6 = p3.x - p1.x;
        float num7 = p3.y - p1.y;
        float num8 = (num6 * num4 - num7 * num3) / num5;
        result.x = p1.x + num8 * num;
        result.y = p1.y + num8 * num2;
        return true;
    }

    internal static bool LineSegmentIntersection(Vector3C p1, Vector3C p2, Vector3C p3, Vector3C p4, ref Vector3C result)
    {
        float num = p2.x - p1.x;
        float num2 = p2.y - p1.y;
        float num3 = p4.x - p3.x;
        float num4 = p4.y - p3.y;
        float num5 = num * num4 - num2 * num3;
        if (num5 == 0f)
        {
            return false;
        }

        float num6 = p3.x - p1.x;
        float num7 = p3.y - p1.y;
        float num8 = (num6 * num4 - num7 * num3) / num5;
        if (num8 < 0f || num8 > 1f)
        {
            return false;
        }

        float num9 = (num6 * num2 - num7 * num) / num5;
        if (num9 < 0f || num9 > 1f)
        {
            return false;
        }

        result.x = p1.x + num8 * num;
        result.y = p1.y + num8 * num2;
        return true;
    }
}
