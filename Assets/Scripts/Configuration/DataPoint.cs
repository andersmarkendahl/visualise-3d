using UnityEngine;

[System.Serializable]
public class DataPoint
{
    public Vector3 Coordinate;
    public MetaLocal Meta;
    public DataPoint(float x, float y, float z, MetaLocal ml)
    {
        Coordinate = new Vector3(x, y, z);
        Meta = ml;
    }
}