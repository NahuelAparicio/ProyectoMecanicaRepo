using System;

[System.Serializable]
public struct CubeC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C scale;
    public Vector3C rotation;
    public float radius;
    #endregion

    #region PROPIERTIES

    #endregion

    #region CONSTRUCTORS
    #endregion

    #region OPERATORS
    public static bool operator ==(CubeC a, CubeC b)
    {
        if (a.position == b.position && a.scale == b.scale && a.rotation == b.rotation)
        {
            return true;
        }
        return false;
    }
    public static bool operator !=(CubeC a, CubeC b)
    {
        if (a.position != b.position && a.scale != b.scale && a.rotation != b.rotation)
        {
            return false;
        }
        return true;
    }


    #endregion

    #region METHODS

    public override bool Equals(object obj)
    {
        if (obj is CubeC)
        {
            CubeC other = (CubeC)obj;
            return other == this;
        }
        return false;
    }
    public bool IsInside(object obj)
    {
        if ()
        {

        }

    }
    #endregion

    #region FUNCTIONS
    #endregion

}