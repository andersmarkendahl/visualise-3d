[System.Serializable]
public class Config
{ 
    public DataPoint[] DataPoints;
    public MetaGlobal Global;

    public Config(MetaGlobal mg, DataPoint[] dps)
    {
        Global = mg;
        DataPoints = dps;
    }
}