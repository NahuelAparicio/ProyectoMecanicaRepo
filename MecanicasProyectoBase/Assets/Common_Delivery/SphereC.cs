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