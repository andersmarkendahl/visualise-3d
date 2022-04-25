using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleFileBrowser;

public class UIManager : MonoBehaviour
{
    public void LoadFile()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.Files, false, null, null, "Load JSON Configuration", "Load" );
        if(FileBrowser.Success)
        {
            Debug.Log(FileBrowser.Result[0]);
            SceneryManager.Instance.LoadLevel("Run");
        }
        else
        {
            Debug.LogError("Failed to open file");
        }
    }
    void Start()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter( "json", ".json"));
        FileBrowser.SetDefaultFilter( ".json" );
    }
}
