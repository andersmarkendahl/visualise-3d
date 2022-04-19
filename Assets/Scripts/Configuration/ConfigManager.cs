using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Dummy data before file can be read
        DataPoint[] _dummyDataPoints = new DataPoint[]
        {
            new DataPoint(0, 0 ,0, new MetaLocal("AAAAAAA")),
            new DataPoint(10, 0 ,0, new MetaLocal("BBBB")),
            new DataPoint(3, 2 ,1, new MetaLocal("Thirty Characters Maximum okay")),
            new DataPoint(7, 6 ,5, new MetaLocal("CCCCCCCCCCCC")),
            new DataPoint(10, 9 ,8, new MetaLocal("Thirty Characters Maximum okay"))
        };
        MetaGlobal _dummyMetaGlobal = new MetaGlobal("Not Much X", "Much X", "Not Much Y", "Much Y", "Not Much Z", "Much Z");
        Config _dummyConfig = new Config(_dummyMetaGlobal, _dummyDataPoints);
        jsonString = JsonUtility.ToJson(_dummyConfig);

        // The real configuration to be assigned here
        Conf = JsonUtility.FromJson<Config>(jsonString);
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
