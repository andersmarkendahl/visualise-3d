using UnityEngine;

[System.Serializable]
public class MetaGlobal
{
    public string
        XLabelStart, XLabelEnd, XDescription,
        YLabelStart, YLabelEnd, YDescription,
        ZLabelStart, ZLabelEnd, ZDescription;
    public MetaGlobal(
        string xStart, string xEnd, string xDesc,
        string yStart, string yEnd, string yDesc,
        string zStart, string zEnd, string zDesc)
    {
        XLabelStart = xStart;
        XLabelEnd = xEnd;
        XDescription = xDesc;
        YLabelStart = yStart;
        YLabelEnd = yEnd;
        YDescription = yDesc;
        ZLabelStart = zStart;
        ZLabelEnd = zEnd;
        ZDescription = zDesc;
    }
}