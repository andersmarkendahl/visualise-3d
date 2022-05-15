using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float Scale;
    public float MoveTime;
    public int CurrentIndex { get => _currentIndex; }

    private int _currentIndex = 0;
    private CameraPosition[] _cameraPositions;
    private bool _moveBlock;

    private IEnumerator CameraZoomIn(Vector3 referencePoint)
    {
        var elapsedTime = 0.0f;
        
        // Start position of camera   
        Vector3 startCoordinates = transform.position;
        // Destination is reference point with offset
        Vector3 destCoordinates = referencePoint + startCoordinates.normalized;

        // Block new user input
        _moveBlock = true;

        // Gradually move camera
        while (elapsedTime < MoveTime)
        {
            transform.position = Vector3.Lerp(startCoordinates, destCoordinates, (elapsedTime / MoveTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = destCoordinates;
    }
    private IEnumerator CameraZoomOut()
    {
        var elapsedTime = 0.0f;
        
        // Start position of camera   
        var startCoordinates = transform.position;
        // Destination is original camera position
        var destCoordinates = _cameraPositions[_currentIndex].Coordinate;

        // Gradually move camera and rotation
        while (elapsedTime < MoveTime)
        {
            transform.position = Vector3.Lerp(startCoordinates, destCoordinates, (elapsedTime / MoveTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = destCoordinates;

        // Allow new user input
        _moveBlock = false;
    }
    private IEnumerator CameraMove(int newIndex)
    {
        var elapsedTime = 0.0f;

        // Collect position and rotation data   
        var startCoordinates = _cameraPositions[_currentIndex].Coordinate;
        var startRotation = _cameraPositions[_currentIndex].Rotation;
        var destCoordinates = _cameraPositions[newIndex].Coordinate;
        var destRotation = _cameraPositions[newIndex].Rotation;

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
    
    private void RotateCamera(int newIndex)
    {
        // Move Camera to new position
        StartCoroutine(CameraMove(newIndex));
        // Update labels to fit new position
        CoordinateSystemManager.Instance.UpdateLabels(newIndex);
    }
    public void UserZoomIn(Vector3 destCoordinates)
    {
        if (_moveBlock)
            return;

        // ZoomIn to coordinate with translation
        StartCoroutine(CameraZoomIn(destCoordinates - 5 * Vector3.one));
        // FadeOut Labels
        CoordinateSystemManager.Instance.FadeOutLabels();
        // FadeOut Axes
        CoordinateSystemManager.Instance.FadeOutAxis();
    }
    public void UserZoomOut()
    {
        // Zoom out to original camera position
        StartCoroutine(CameraZoomOut());
        // Fade in labels
        CoordinateSystemManager.Instance.FadeInLabels();
        // Fade in axes
        CoordinateSystemManager.Instance.FadeInAxis();
    }

    public void UserRotate(Control value)
    {
        if (_moveBlock)
            return;

        // Map user input to camera position
        switch (_currentIndex)
        {
        case 0:
            if (value == Control.UP)
                RotateCamera(2);
            else if (value == Control.RIGHT)
                RotateCamera(1);
            break;
        case 1:
            if (value == Control.LEFT)
                RotateCamera(0);
            else if (value == Control.UP)
                RotateCamera(2);
            break;
        case 2:
            if (value == Control.DOWN)
                RotateCamera(0);
            else if (value == Control.RIGHT)
                RotateCamera(1);
            break;
        default:
            Debug.Log("Unknown current index for camera position" + _currentIndex);
            break;
        }
    }
    void Awake()
    {
        Instance = this;
        // Define the three camera positions
        _cameraPositions = new CameraPosition[]
        {
            new CameraPosition(new Vector3(0.0f, 0.0f, -Scale), new Vector3(0.0f, 0.0f, 0.0f)),
            new CameraPosition(new Vector3(Scale, 0.0f, 0.0f), new Vector3(0.0f, -90.0f, 0.0f)),
            new CameraPosition(new Vector3(0.0f, Scale, 0.0f), new Vector3(90.0f, 0.0f, 0.0f)),
        };
    }
    void Start()
    {
        // Switch to default starting position
        RotateCamera(_currentIndex);
    }
}