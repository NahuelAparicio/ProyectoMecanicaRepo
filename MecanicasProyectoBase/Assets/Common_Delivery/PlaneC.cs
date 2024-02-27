using System;
using UnityEngine;

[System.Serializable]
public struct PlaneC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C normal;
    //public int size;
    //public float _distance;
    #endregion

    #region PROPIERTIES

  //  public Vector3C normal { get { return normal; } set { normal = value; } }
    //public float distance { get { return _distance; } set { _distance = value; } }

    //public PlaneC flipped { get { return new PlaneC(-_normal, 0f - _distance); } }

    public static Vector3C right { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C up { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C forward { get { return new Vector3C(0, 0, 1); } }
    #endregion

    #region CONSTRUCTORS
    //public PlaneC(Vector3C nNormal, Vector3C nPoint)
    //{
    //    _normal = nNormal;
    //    _distance = 0f - Vector3C.Dot(_normal, nPoint);
    //}

    //public Plane(Vector3C nNormal, float d)
    //{
    //    _normal = Vector3C.Normalize(nNormal);
    //    _distance = d;
    //}

    //public Plane(Vector3 a, Vector3 b, Vector3 c)
    //{
    //    m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
    //    m_Distance = 0f - Vector3.Dot(m_Normal, a);
    //}

    public PlaneC(Vector3C position, Vector3C normal)
    {
        this.position = position;
        this.normal = normal;
    }
    public PlaneC(Vector3C n, float D)
    {
        this.position = new Vector3C();
        this.normal = new Vector3C();
    }
    #endregion

    #region OPERATORS
    public static bool operator ==(PlaneC lhs, PlaneC rhs)
    {
        if (lhs.position == rhs.position && lhs.normal == rhs.normal)
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(PlaneC lhs, PlaneC rhs)
    {
        if (lhs.position != rhs.position && lhs.normal != rhs.normal)
        {
            return true;
        }
        return false;
    }
    #endregion

    #region METHODS
    public void ToEquation()
    {
        
    }
    public Vector3C NearestPoint(PlaneC myPlane, Vector3C extPoint)
    {
        // Vector desde el punto en el plano al punto externo
        Vector3C vectorToExtPoint = extPoint - myPlane.position;

        // Proyección del vector sobre la normal del plano
        float distance = Vector3C.Dot(vectorToExtPoint, myPlane.normal);

        // Punto más cercano en el plano
        Vector3C nearestPoint = extPoint - distance * myPlane.normal;
        return nearestPoint;
    }
    public Vector3C IntersectionPoint(PlaneC myPlane, LineC myLine)
    {
        // Calculamos el numerador de la fórmula de intersección
        float numerator = Vector3C.Dot(myPlane.normal, (myPlane.position - myLine.origin));

        // Calculamos el denominador de la fórmula de intersección
        float denominator = Vector3C.Dot(myPlane.normal, myLine.direction);

        // Si el valor absoluto del denominador es pequeño, la línea es paralela al plano
        const float epsilon = 1e-6f; // Valor pequeño para comparación aproximada
        if (Math.Abs(denominator) < epsilon)
        {
            // En este caso, la línea está contenida en el plano o es paralela a él
            // Puedes manejar este caso según tus necesidades
            throw new InvalidOperationException("La línea es paralela al plano.");
        }

        // Calculamos el parámetro t de la intersección
        float t = numerator / denominator;

        // Calculamos el punto de intersección
        Vector3C intersectionPoint = myLine.origin + t * myLine.direction;

        return intersectionPoint;


    }
    public override bool Equals(object obj)
    {
        if (obj is PlaneC)
        {
            PlaneC other = (PlaneC)obj;
            return other == this;
        }
        return false;
    }
    #endregion

    #region FUNCTIONS
    #endregion

}