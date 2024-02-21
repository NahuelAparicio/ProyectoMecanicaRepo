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
    public Vector3C PointToPoint(Vector3C extPoint, LineC myLine)
    {
        Vector3C vectorAB = myLine.direction;
        Vector3C vectorAP = extPoint - myLine.origin;

        float t = Vector3C.Dot(vectorAP, vectorAB) / Vector3C.Dot(vectorAB, vectorAB);

        // Clampeamos t para asegurarnos de que el punto est� en el segmento AB
        t = Utils.Clamp01(t);

        Vector3C closestPoint = myLine.origin + t * vectorAB;
        return closestPoint;


    }
    public Vector3C PointToLine(LineC myExternLine, LineC myLine)
    {
        Vector3C vectorBetweenOrigins = myExternLine.origin - myLine.origin;

        float t = Vector3C.Dot(vectorBetweenOrigins, myLine.direction) / Vector3C.Dot(myLine.direction, myLine.direction);

        // Clampeamos t para asegurarnos de que el punto est� en la l�nea myLine
        t = Utils.Clamp01(t);

        Vector3C closestPoint = myLine.origin + t * myLine.direction;
        return closestPoint;

    }
    #endregion

    #region FUNCTIONS
    public LineC LineFromPointAPointB(Vector3C pointA, Vector3C pointB)
    {
        // El origen de la l�nea puede ser cualquiera de los dos puntos
        Vector3C lineOrigin = pointA;

        // La direcci�n de la l�nea es un vector que apunta de pointA a pointB
        Vector3C lineDirection = pointB - pointA;
        lineDirection.Normalize();

        // Creamos y devolvemos 
        LineC newLine = new LineC(lineOrigin, lineDirection);
        return newLine;

    }
    #endregion

}