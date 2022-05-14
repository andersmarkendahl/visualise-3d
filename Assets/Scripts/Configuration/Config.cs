[System.Serializable]
public class Config
{ 
    public DataPoint[] DataPoints;
    public MetaGlobal Meta;

    public Config(MetaGlobal mg, DataPoint[] dps)
    {
        Meta = mg;
        DataPoints = dps;
    }
}