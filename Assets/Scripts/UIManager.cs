using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using SimpleFileBrowser;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text ErrorMessage;
    public void LoadFile()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    public void Quit()
    {
        Application.Quit();
    }
    private string PlayerLog()
    {
        string playerLog;

#if UNITY_STANDALONE_LINUX
        playerLog = "~/.config/unity3d/" + Application.companyName + "/" + Application.productName +  "/Player.log";
#endif
#if UNITY_STANDALONE_OSX
        playerLog = "~/Library/Logs/" + Application.companyName + "/" + Application.productName + "/Player.log";
#endif

        return playerLog;
    }
    private void ValidateConf(string path)
    {
        var divider = "==========================================================";
        // Read the entire file and save its contents.
        var jsonString = File.ReadAllText(path);
        // Deserialize the JSON data into a pattern matching the Config class.
        Config conf = JsonUtility.FromJson<Config>(jsonString);

        Debug.LogError(divider);
        Debug.LogError("===== Starting validation of " + path + " =====");
        if(Validation.Validate(conf))
        {
            PlayerPrefs.SetString("path", path);
            SceneryManager.Instance.LoadLevel("Run");
            Debug.LogError("===== Validation of " + path + " PASSED =====");
            Debug.LogError(divider);
        }
        else
        {
            var playerLog = PlayerLog();
            Debug.LogError("===== Validation of " + path + " FAILED =====");
            Debug.LogError(divider);
            ErrorMessage.text =
                "WARNING: Validation failed for file " + path +
                "\nPlease see end of " + playerLog + " for errors";
        }
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.Files, false, null, null, "Load JSON Configuration", "Load" );
        if(FileBrowser.Success)
        {
            // Validate configuration and run if ok
            var path = FileBrowser.Result[0];
            ValidateConf(path );
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
