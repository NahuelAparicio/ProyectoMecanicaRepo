using System;

[System.Serializable]
public struct SphereC
{
    #region FIELDS
    public Vector3C position;
    public float radius;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    #endregion

    #region OPERATORS

    public static bool operator ==(SphereC lhs, SphereC rhs)
    {
        return true;
    }
    public static bool operator !=(SphereC lhs, SphereC rhs)
    {
        return false;

    }

    #endregion

    #region METHODS
    public override bool Equals(object obj)
    {
        if (obj is SphereC)
        {
            SphereC other = (SphereC)obj;
            return other == this;
        }
        return false;
    }
    public bool IsInside(SphereC sphere)
    {
        return true;
       
    }
    #endregion

    #region FUNCTIONS
    #endregion

}