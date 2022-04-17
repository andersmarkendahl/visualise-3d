using UnityEngine;

[System.Serializable]
public class DataPoint
{
    public Vector3 Coordinate;
    public MetaDataPoint Info;
    public DataPoint(float x, float y, float z, MetaDataPoint info)
    {
        Coordinate = new Vector3(x, y, z);
        Info = info;
    }
}