[System.Serializable]
public class Config
{ 
    public DataPoint[] DataPoints;
    public MetaData Meta;

    public Config(MetaData mdata, DataPoint[] data)
    {
        Meta = mdata;
        DataPoints = data;
    }
}