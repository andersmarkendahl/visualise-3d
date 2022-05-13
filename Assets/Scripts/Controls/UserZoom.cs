using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserZoom : MonoBehaviour
{
    public static UserZoom Instance;

    public void StarZoomIn(StarInfoManager starInfoManager)
    {
        CameraControl.Instance.UserZoomIn(starInfoManager.Dpoint.Coordinate);
    }
    public void StarZoomOut(StarInfoManager starInfoManager)
    {
        CameraControl.Instance.UserZoomOut();
    }
    void Awake()
    {
        Instance = this;
    }
}
