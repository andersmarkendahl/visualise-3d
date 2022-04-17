using UnityEngine;

[System.Serializable]
public class MetaLocal
{
    public string Header;
    public MetaLocal(string header)
    {
        Header = header;
    }
    public override string ToString()
	{
		return
			" Header=" + Header;
	}
}