using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float Scale;
    public float MoveTime;
    public GameObject UpLabel, DownLabel, LeftLabel, RightLabel;

    private Text _upText, _downText, _leftText, _rightText;
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
    private IEnumerator LabelChange(int newIndex)
    {
        var elapsedTime = 0.0f;
        var halfMoveTime = MoveTime/2;
        var origAlpha = _upText.color.a;

        // Gradually Fade Out Labels
        while (elapsedTime < halfMoveTime)
        {
            float alpha = Mathf.Lerp(origAlpha, 0.0f, (elapsedTime / halfMoveTime));
            _upText.color = new Color(_upText.color.r, _upText.color.g, _upText.color.b, alpha);
            _downText.color = new Color(_downText.color.r, _downText.color.g, _downText.color.b, alpha);
            _leftText.color = new Color(_leftText.color.r, _leftText.color.g, _leftText.color.b, alpha);
            _rightText.color = new Color(_rightText.color.r, _rightText.color.g, _rightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        switch (newIndex)
        {
        case 0:
            _upText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        case 1:
            _upText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            break;
        case 2:
            _upText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        }
        // Gradually Fade In Labels
        elapsedTime = 0.0f;
        while (elapsedTime < halfMoveTime)
        {
            float alpha = Mathf.Lerp(0.0f, origAlpha, elapsedTime/halfMoveTime);
            _upText.color = new Color(_upText.color.r, _upText.color.g, _upText.color.b, alpha);
            _downText.color = new Color(_downText.color.r, _downText.color.g, _downText.color.b, alpha);
            _leftText.color = new Color(_leftText.color.r, _leftText.color.g, _leftText.color.b, alpha);
            _rightText.color = new Color(_rightText.color.r, _rightText.color.g, _rightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    private void SetCameraPosition(int newIndex)
    {
        StartCoroutine(CameraMove(newIndex));
        StartCoroutine(LabelChange(newIndex));
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
        // Assign Text variables
        _upText = UpLabel.GetComponent<Text>();
        _downText = DownLabel.GetComponent<Text>();
        _leftText = LeftLabel.GetComponent<Text>();
        _rightText = RightLabel.GetComponent<Text>();
        // Switch to default starting position
        SetCameraPosition(_currentIndex);
    }

}