using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class UIManager : MonoBehaviour
{
    public void LoadFile()
    {
        string path = EditorUtility.OpenFilePanel("Open data file", "", "json");
        Debug.Log(path);
        SceneryManager.Instance.LoadLevel("Run");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
