using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserZoom : MonoBehaviour
{
    public static UserZoom Instance;

    public void StarClicked(StarInfoManager starInfoManager)
    {
        Debug.Log("Got StarInfoManager, id=" + starInfoManager.Id);
    }
    void Awake()
    {
        Instance = this;
    }
}
