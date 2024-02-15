using System;

[System.Serializable]
public struct PlaneC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C normal;
    #endregion

    #region PROPIERTIES
    public static PlaneC right { get { return new Vector3C(1, 0, 0); } }
    public static PlaneC up { get { return new Vector3C(0, 1, 0); } }
    public static PlaneC forward { get { return new Vector3C(0, 0, 1); } }
    #endregion

    #region CONSTRUCTORS
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
    #endregion

    #region METHODS
    public void ToEquation()
    {
        
    }
    public void NearestPoint()
    {
       
    }
    public void Intersection()
    {

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