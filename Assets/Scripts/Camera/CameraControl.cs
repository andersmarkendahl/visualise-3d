using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float Scale;
    public float MoveTime;
    public GameObject UpLabel, DownLabel, LeftLabel, RightLabel;

    private TMP_Text _upText, _downText, _leftText, _rightText;
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
            _upText.text = ConfigManager.Instance.Conf.Global.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Global.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Global.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Global.XLabelEnd;
            break;
        case 1:
            _upText.text = ConfigManager.Instance.Conf.Global.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Global.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Global.ZLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Global.ZLabelEnd;
            break;
        case 2:
            _upText.text = ConfigManager.Instance.Conf.Global.ZLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Global.ZLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Global.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Global.XLabelEnd;
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
    private void RotateCamera(int newIndex)
    {
        StartCoroutine(CameraMove(newIndex));
        StartCoroutine(LabelChange(newIndex));
    }
    public void UserRotate( Control value )
    {
        if (_moveBlock)
            return;

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
        _cameraPositions = new CameraPosition[]
        {
            new CameraPosition(new Vector3(0.0f, 0.0f, -Scale), new Vector3(0.0f, 0.0f, 0.0f)),
            new CameraPosition(new Vector3(Scale, 0.0f, 0.0f), new Vector3(0.0f, -90.0f, 0.0f)),
            new CameraPosition(new Vector3(0.0f, Scale, 0.0f), new Vector3(90.0f, 0.0f, 0.0f)),
        };
        // Assign Text variables
        _upText = UpLabel.GetComponent<TMP_Text>();
        _downText = DownLabel.GetComponent<TMP_Text>();
        _leftText = LeftLabel.GetComponent<TMP_Text>();
        _rightText = RightLabel.GetComponent<TMP_Text>();
        // Switch to default starting position
        RotateCamera(_currentIndex);
    }

}