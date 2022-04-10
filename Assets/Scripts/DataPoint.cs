using UnityEngine;

[System.Serializable]
public class DataPoint
{
    public Vector3 Coordinate;

    public DataPoint(float x, float y, float z)
    {
        Coordinate = new Vector3(x, y, z);
    }
}