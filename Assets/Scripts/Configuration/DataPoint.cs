using UnityEngine;

[System.Serializable]
public class DataPoint
{
    public Vector3 Coordinate;
    public MetaLocal Local;
    public DataPoint(float x, float y, float z, MetaLocal local)
    {
        Coordinate = new Vector3(x, y, z);
        Local = local;
    }
}