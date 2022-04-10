[System.Serializable]
public class Config
{ 
    public DataPoint[] DataPoints;

    public Config(DataPoint[] data)
    {
        DataPoints = data;
    }
}