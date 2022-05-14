using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;
    public GameObject StarPrefab;
    public Config Conf;
    public Vector3 CoordinateTranslation { get => _coordinateTranslation; }

    private Vector3 _coordinateTranslation;
    private DataPoint[] _dataPoints;
    private string jsonString;


    void Awake()
    {
        Instance = this;
        _coordinateTranslation = -5 * Vector3.one;
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
        int id = 0;
        foreach (DataPoint dp in Conf.DataPoints)
        {
            GameObject s = Instantiate(StarPrefab, dp.Coordinate + _coordinateTranslation , Quaternion.identity);
            s.GetComponent<StarInfoManager>().Dpoint = dp;
            s.GetComponent<StarInfoManager>().Id = id;
            id++;
        }

    }
}
