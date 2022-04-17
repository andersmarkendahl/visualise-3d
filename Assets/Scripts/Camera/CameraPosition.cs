using UnityEngine;
using UnityEngine.UI;

public class CameraPosition
{
    public Vector3 Coordinate;
    public Vector3 Rotation;

    public CameraPosition(Vector3 coordinate, Vector3 rotation)
    {
        Coordinate = coordinate;
        Rotation = rotation;
    }
}