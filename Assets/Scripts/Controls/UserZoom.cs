using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserZoom : MonoBehaviour
{
    public static UserZoom Instance;

    public void StarClicked(StarInfoManager starInfoManager)
    {
        CameraControl.Instance.UserZoomIn(starInfoManager.Dpoint.Coordinate);
    }
    void Awake()
    {
        Instance = this;
    }
}
