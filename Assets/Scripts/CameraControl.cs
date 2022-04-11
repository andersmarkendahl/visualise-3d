using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public float Scale;
    public float MoveTime;
    public GameObject UpLabel, DownLabel, LeftLabel, RightLabel;
    private Text UpText, DownText, LeftText, RightText;

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
        var origAlpha = UpText.color.a;

        // Gradually Fade Out Labels
        while (elapsedTime < halfMoveTime)
        {
            float alpha = Mathf.Lerp(origAlpha, 0.0f, (elapsedTime / halfMoveTime));
            UpText.color = new Color(UpText.color.r, UpText.color.g, UpText.color.b, alpha);
            DownText.color = new Color(DownText.color.r, DownText.color.g, DownText.color.b, alpha);
            LeftText.color = new Color(LeftText.color.r, LeftText.color.g, LeftText.color.b, alpha);
            RightText.color = new Color(RightText.color.r, RightText.color.g, RightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        switch (newIndex)
        {
        case 0:
            UpText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            DownText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            LeftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            RightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        case 1:
            UpText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            DownText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            LeftText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            RightText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            break;
        case 2:
            UpText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            DownText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            LeftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            RightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        }
        // Gradually Fade In Labels
        elapsedTime = 0.0f;
        while (elapsedTime < halfMoveTime)
        {
            float alpha = Mathf.Lerp(0.0f, origAlpha, elapsedTime/halfMoveTime);
            UpText.color = new Color(UpText.color.r, UpText.color.g, UpText.color.b, alpha);
            DownText.color = new Color(DownText.color.r, DownText.color.g, DownText.color.b, alpha);
            LeftText.color = new Color(LeftText.color.r, LeftText.color.g, LeftText.color.b, alpha);
            RightText.color = new Color(RightText.color.r, RightText.color.g, RightText.color.b, alpha);
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
        UpText = UpLabel.GetComponent<Text>();
        DownText = DownLabel.GetComponent<Text>();
        LeftText = LeftLabel.GetComponent<Text>();
        RightText = RightLabel.GetComponent<Text>();
        // Switch to default starting position
        SetCameraPosition(_currentIndex);
    }

}