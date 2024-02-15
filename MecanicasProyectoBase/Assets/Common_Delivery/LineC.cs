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
        //S'HA DE NORMALITZAR
       //direction.Normalize();
    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS
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