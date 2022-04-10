using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public GameObject DataPointPrefab;
    // Start is called before the first frame update
    private Config _config;
    private DataPoint[] _dataPoints;
    private string jsonString;
    void Awake()
    {
        // Dummy data before file can be read
        DataPoint[] _dummyDataPoints = new DataPoint[]
        {
            new DataPoint(0, 0 ,0),
            new DataPoint(10, 0 ,0),
            new DataPoint(0, 10 ,0),
            new DataPoint(0, 0 ,10),
            new DataPoint(10, 10 ,0),
            new DataPoint(0, 10 ,10),
            new DataPoint(10, 0 ,10),
            new DataPoint(10, 10 ,10)   
        };
        Config _dummyConfig = new Config(_dummyDataPoints);
        jsonString = JsonUtility.ToJson(_dummyConfig);

        // The real variable
        _config = JsonUtility.FromJson<Config>(jsonString);
    }
    void Start()
    {
        foreach (DataPoint dp in _config.DataPoints)
        {
            Instantiate(DataPointPrefab, dp.Coordinate , Quaternion.identity);
        }
    }
}
