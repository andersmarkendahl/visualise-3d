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
    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.Files, false, null, null, "Load JSON Configuration", "Load" );
        if(FileBrowser.Success)
        {
            // Validate configuration
            var path = FileBrowser.Result[0];
            // Read the entire file and save its contents.
            var jsonString = File.ReadAllText(path);
            // Deserialize the JSON data into a pattern matching the Config class.
            Config conf = JsonUtility.FromJson<Config>(jsonString);

            if(Validation.Validate(conf))
            {
                PlayerPrefs.SetString("path", path);
                SceneryManager.Instance.LoadLevel("Run");
            }
            else
            {
                Debug.LogError("Failed to validate file: " + path);
                ErrorMessage.text =
                    "WARNING: Validation failed for file " + path +
                    "\nPlease see " + "REPLACELOGS" + " for errors";
            }
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
