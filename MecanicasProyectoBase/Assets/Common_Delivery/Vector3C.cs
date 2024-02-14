using System;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public struct Vector3C
{
    #region FIELDS
    public float x;
    public float y;
    public float z;
    #endregion

    #region PROPIERTIES
    public float r { get => x; set => x = value; }
    public float g { get => y; set => y = value; }
    public float b { get => z; set => z = value; }
    public float magnitude { get => Magnitude(this); }
    public float sqrMagnitude { get => SqrMagnitude(this); }
    public Vector3C normalized { get => Normalize(this); }

    public static Vector3C zero { get { return new Vector3C(0, 0, 0); } }
    public static Vector3C one { get { return new Vector3C(1, 1, 1); } }
    public static Vector3C right { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C up { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C forward { get { return new Vector3C(0, 0, 1); } }

    public static Vector3C black { get { return new Vector3C(0, 0, 0); } }
    public static Vector3C white { get { return new Vector3C(1, 1, 1); } }
    public static Vector3C red { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C green { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C blue { get { return new Vector3C(0, 0, 1); } }
    #endregion

    #region CONSTRUCTORS
    public Vector3C(float x = 0, float y = 0, float z = 0)
    {
        this.x = x; this.y = y; this.z = z;
    }
    #endregion


    #region OPERATORS
    public static Vector3C operator +(Vector3C a, Vector3C b)
    {
        return new Vector3C(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    public static Vector3C operator -(Vector3C a, Vector3C b)
    {
        return new Vector3C(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    public static Vector3C operator /(Vector3C a, float num)
    {
        return new Vector3C(a.x / num, a.y / num, a.z / num);
    }

    public static Vector3C operator *(Vector3C a, float num)
    {
        return new Vector3C(a.x * num, a.y * num, a.z * num);
    }

    public static Vector3C operator *(float num, Vector3C a)
    {
        return new Vector3C(a.x * num, a.y * num, a.z * num);
    }

    public static bool operator ==(Vector3C a, Vector3C b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z)
        {
            return true;
        }
        return false;
    }
    public static bool operator !=(Vector3C a, Vector3C b)
    {
        if (a.x != b.x && a.y != b.y && a.z != b.z)
        {
            return true;
        }
        return false;
    }
    #endregion

    #region METHODS

    public override bool Equals(object obj)
    {
        if (obj is Vector3C)
        {
            Vector3C other = (Vector3C)obj;
            return other == this;
        }
        return false;
    }

    public void Normalize()
    {
        float num = Magnitude(this);
        if (num > 1E-05f)
        {
            this /= num;
        }
        else
        {
            this = zero;
        }
    }

    public Vector3C Normalize(Vector3C vec)
    {
        float magnitude = Magnitude(vec);
        if (magnitude > 0.0f)
        {
            return vec / magnitude;
        }
        return zero;
    }
    public float Magnitude(Vector3C vec) => (float)Math.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
    public float SqrMagnitude(Vector3C vec) => (float)(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
    #endregion

    #region FUNCTIONS

    public static float Distance(Vector3C vec1, Vector3C vec2)
    {
        float num = vec1.x - vec2.x;
        float num2 = vec1.y - vec2.y;
        float num3 = vec1.z - vec2.z;
        return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
    }

    public static float Dot(Vector3C v1, Vector3C v2)
    {
        return v1.x * v2.x + v1.y + v2.y + v1.z + v2.z;
    }
    public static Vector3C Cross(Vector3C v1, Vector3C v2)
    {
        return new Vector3C(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
    }

    // - Angle in Degrees Between 2 Vecs
    public static float Angle(Vector3C from, Vector3C to)
    {
        float num = (float)Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
        if (num == 0)
        {
            return 0f;
        }
        float num2 = Utils.Clamp(Dot(from, to) / num, -1f, 1f);
        return (float)Math.Acos(num2) * 57.29f;
    }

    #endregion

}