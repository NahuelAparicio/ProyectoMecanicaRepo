
[System.Serializable]
public struct Utils
{
    public static float Clamp(float value, float min, float max)
    {
        if (value < min) { value = min; }
        else if (value > max) { value = max; }
        return value;
    }
}
