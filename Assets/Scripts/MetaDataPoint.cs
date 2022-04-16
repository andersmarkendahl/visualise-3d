using UnityEngine;

[System.Serializable]
public class MetaDataPoint
{
    public string Header;
    public MetaDataPoint(string header)
    {
        Header = header;
    }
    public override string ToString()
	{
		return
			" Header=" + Header;
	}
}