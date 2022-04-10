using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float Scale;
    public float MoveTime;

    private CameraPosition[] _cameraPositions;
    private int _currentIndex = 0;
    private bool _moveBlock;

	private IEnumerator CameraMove(int newIndex)
	{
		var elapsedTime = 0.0f;

        // Collect position and rotation data   
        Vector3 startCoordinates = _cameraPositions[_currentIndex].Coordinate;
        Vector3 startRotation = _cameraPositions[_currentIndex].Rotation;
        Vector3 destCoordinates = _cameraPositions[newIndex].Coordinate;
        Vector3 destRotation = _cameraPositions[newIndex].Rotation;

		// Block new user input
        _moveBlock = true;

		// Gradually move camera and rotation
		while (elapsedTime < MoveTime)
		{
			transform.position = Vector3.Lerp(startCoordinates, destCoordinates, (elapsedTime / MoveTime));
            transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, destRotation, (elapsedTime / MoveTime)));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = destCoordinates;
        transform.rotation = Quaternion.Euler(destRotation);

		// Allow new user input
		_moveBlock = false;
        // Update Index when movement done
        _currentIndex = newIndex;
	}
    private void SetCameraPosition(int newIndex)
    {
        StartCoroutine(CameraMove(newIndex));
    }
    public void UserInput( Control value )
    {
        if (_moveBlock)
            return;

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
            new CameraPosition(new Vector3(0.0f, 0.0f, -Scale), new Vector3(0.0f, 0.0f, 0.0f)),
            new CameraPosition(new Vector3(Scale, 0.0f, 0.0f), new Vector3(0.0f, -90.0f, 0.0f)),
            new CameraPosition(new Vector3(0.0f, Scale, 0.0f), new Vector3(90.0f, 0.0f, 0.0f)),
        };
        // Switch to default starting position
        SetCameraPosition(_currentIndex);
    }

}