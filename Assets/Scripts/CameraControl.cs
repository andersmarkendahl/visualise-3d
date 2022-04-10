using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    private CameraPosition[] _cameraPositions;
    private int _currentIndex = 0;
    public float scale = 10.0f;
    public CameraControl instance;

    private void SetCameraPosition(int index)
    {
        gameObject.transform.position = _cameraPositions[index].Coordinate;
        gameObject.transform.rotation = Quaternion.Euler(_cameraPositions[index].Rotation);
        _currentIndex = index;
    }
    public void UserInput()
    {

    }
    void Awake()
    {
        instance = this;
        _cameraPositions = new CameraPosition[]
        {
            new CameraPosition(new Vector3(0.0f, 0.0f, -scale), new Vector3(0.0f, 0.0f, 0.0f)),
            new CameraPosition(new Vector3(scale, 0.0f, 0.0f), new Vector3(0.0f, -90.0f, 0.0f)),
            new CameraPosition(new Vector3(0.0f, scale, 0.0f), new Vector3(90.0f, 0.0f, 0.0f)),
        };
        // Switch to default starting position
        SetCameraPosition(_currentIndex);
    }

}