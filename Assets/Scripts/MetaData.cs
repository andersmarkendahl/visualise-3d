using UnityEngine;

[System.Serializable]
public class MetaData
{
    public string XLabelStart, XLabelEnd, YLabelStart, YLabelEnd, ZLabelStart, ZLabelEnd;
    public MetaData(string xStart, string xEnd, string yStart, string yEnd, string zStart, string zEnd)
    {
        XLabelStart = xStart;
        XLabelEnd = xEnd;
        YLabelStart = yStart;
        YLabelEnd = yEnd;
        ZLabelStart = zStart;
        ZLabelEnd = zEnd;
    }
}