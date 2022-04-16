using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;
    public GameObject DataPointPrefab;
    public Config Conf;
    private DataPoint[] _dataPoints;
    private string jsonString;
    void Awake()
    {
        Instance = this;
        // Dummy data before file can be read
        DataPoint[] _dummyDataPoints = new DataPoint[]
        {
            new DataPoint(0, 0 ,0, new MetaDataPoint("AAAA")),
            new DataPoint(10, 0 ,0, new MetaDataPoint("BBBB")),
            new DataPoint(3, 2 ,1, new MetaDataPoint("Thirty Characters Maximum okay")),
            new DataPoint(7, 6 ,5, new MetaDataPoint("KKKK")),
            new DataPoint(10, 9 ,8, new MetaDataPoint("Thirty Characters Maximum okay"))
        };
        MetaData _dummyMetaData = new MetaData("Not Much X", "Much X", "Not Much Y", "Much Y", "Not Much Z", "Much Z");
        Config _dummyConfig = new Config(_dummyMetaData, _dummyDataPoints);
        jsonString = JsonUtility.ToJson(_dummyConfig);

        // The real configuration to be assigned here
        Conf = JsonUtility.FromJson<Config>(jsonString);
    }
    void Start()
    {
        foreach (DataPoint dp in Conf.DataPoints)
        {
            GameObject d = Instantiate(DataPointPrefab, dp.Coordinate - 5 * new Vector3(1.0f, 1.0f, 1.0f) , Quaternion.identity);
            d.GetComponent<InfoManager>().Info = dp.Info;
        }

    }
}
