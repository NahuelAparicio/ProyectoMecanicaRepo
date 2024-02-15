using System;

[System.Serializable]
public struct LineC
{
    #region FIELDS
    public Vector3C origin;
    public Vector3C direction;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public LineC(Vector3C origin, Vector3C direction)
    {
        this.origin = origin;
        this.direction = direction;
        direction.Normalize();
    }
    #endregion

    #region OPERATORS

    public static bool operator ==(LineC lhs, LineC rhs)
    {
        if (lhs.origin == rhs.origin && lhs.direction == rhs.direction)
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(LineC lhs, LineC rhs)
    {
        if (lhs.origin != rhs.origin && lhs.direction != rhs.direction)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region METHODS

    public override bool Equals(object obj)
    {
        if(obj is LineC)
        {
            LineC other = (LineC)obj;
            return other == this;
        }
        return false;  
    }
    public void PointToPoint(Vector3C extPoint, LineC myLine)
    {

    }
    public void PointToLine(LineC myExternLine, LineC myLine)
    {

    }
    #endregion

    #region FUNCTIONS
    #endregion

}