using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;
    public GameObject StarPrefab;
    public Config Conf;
    private DataPoint[] _dataPoints;
    private string jsonString;
    void Awake()
    {
        Instance = this;
        string path = PlayerPrefs.GetString("path");
        if (File.Exists(path))
		{
			// Read the entire file and save its contents.
			jsonString = File.ReadAllText(path);
			// Deserialize the JSON data into a pattern matching the Config class.
            Conf = JsonUtility.FromJson<Config>(jsonString);
		}
        else
        {
            Debug.LogError("Failed to read " + path);
        }
    }
    void Start()
    {
        foreach (DataPoint dp in Conf.DataPoints)
        {
            GameObject s = Instantiate(StarPrefab, dp.Coordinate - 5 * new Vector3(1.0f, 1.0f, 1.0f) , Quaternion.identity);
            s.GetComponent<StarInfoManager>().Dpoint = dp;
        }

    }
}
