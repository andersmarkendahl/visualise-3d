using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float scale = 10.0f;

    private CameraPosition[] _cameraPositions;
    private int _currentIndex = 0;

    private void SetCameraPosition(int index)
    {
        gameObject.transform.position = _cameraPositions[index].Coordinate;
        gameObject.transform.rotation = Quaternion.Euler(_cameraPositions[index].Rotation);
        _currentIndex = index;
    }
    public void UserInput( Control value )
    {
        switch (_currentIndex)
        {
        case 0:
            if (value == Control.UP)
                SetCameraPosition(2);
            else if (value == Control.RIGHT)
                SetCameraPosition(1);
            break;
        case 1:
            if (value == Control.LEFT)
                SetCameraPosition(0);
            else if (value == Control.UP)
                SetCameraPosition(2);
            break;
        case 2:
            if (value == Control.DOWN)
                SetCameraPosition(0);
            else if (value == Control.RIGHT)
                SetCameraPosition(1);
            break;
        default:
            Debug.Log("Unknown current index for camera position" + _currentIndex);
            break;
        }
    }
    void Awake()
    {
        Instance = this;
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