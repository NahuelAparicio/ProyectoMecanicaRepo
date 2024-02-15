using System;

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
    public CapsuleC(float posA = 0, float posB = 0, float radius=0)
    {
        this.x = posA; this.y = posB;
    }
    public CapsuleC(Vector3C position = (0,0,0), float radius = 0, float height = 0, float rotation = 0)
    {
        this.x = posA; this.y = posB;
    }
    #endregion

    #region OPERATORS
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