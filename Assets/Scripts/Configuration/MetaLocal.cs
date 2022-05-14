using UnityEngine;

[System.Serializable]
public class MetaLocal
{
    public string Header;
    public string Description;
    public MetaLocal(string header, string description)
    {
        Header = header;
        Description = description;
    }
    public override string ToString()
	{
		return
			" Header=" + Header +
            " Description=" + Description;
	}
}