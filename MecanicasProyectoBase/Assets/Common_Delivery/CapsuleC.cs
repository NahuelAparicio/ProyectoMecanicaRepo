using System;
using System.Runtime.InteropServices.WindowsRuntime;

[System.Serializable]
public struct CapsuleC
{
    #region FIELDS
    public Vector3C positionA;
    public Vector3C positionB;
    public float radius;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public CapsuleC(Vector3C posA, Vector3C posB, float _radius)
    {
        this.positionA = posA;
        this.positionB = posB;
        this.radius = _radius;
    }
    #endregion

    #region OPERATORS
    public static bool operator == (CapsuleC lhs, CapsuleC rhs)
    {
        if (lhs.positionA == rhs.positionA && lhs.positionB == rhs.positionB && lhs.radius == rhs.radius)
        {
            return true;
        }
        return false;
    }
    public static bool operator != (CapsuleC lhs, CapsuleC rhs)
    {
        if (lhs.positionA != rhs.positionA && lhs.positionB != rhs.positionB && lhs.radius != rhs.radius)
        {
            return true;
        }
        return false;
    }
    #endregion

    #region METHODS
    public override bool Equals(object obj)
    {
        if (obj is CapsuleC)
        {
            CapsuleC other = (CapsuleC)obj;
            return other == this;
        }
        return false;
    }
    public bool IsCapsuleInside(CapsuleC otherCapsule)
    {
        // Verificar si ambas esferas están contenidas dentro de la cápsula más grande
        if (Vector3C.Distance(positionA, otherCapsule.positionA) + radius < otherCapsule.radius &&
            Vector3C.Distance(positionB, otherCapsule.positionA) + radius < otherCapsule.radius &&
            Vector3C.Distance(positionA, otherCapsule.positionB) + radius < otherCapsule.radius &&
            Vector3C.Distance(positionB, otherCapsule.positionB) + radius < otherCapsule.radius)
        {
            // Verificar si el cilindro central está completamente contenido
            Vector3C capsuleDirection = positionB - positionA;
            Vector3C otherCapsuleDirection = otherCapsule.positionB - otherCapsule.positionA;

            float distanceBetweenCenters = Vector3C.Distance(positionA, otherCapsule.positionA);

            if (distanceBetweenCenters + radius < otherCapsule.radius &&
                distanceBetweenCenters + otherCapsule.radius < radius &&
                Vector3C.Dot(capsuleDirection, otherCapsuleDirection) > 0)
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    #region FUNCTIONS
    #endregion

}