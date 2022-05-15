using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation
{
    public static bool Validate(Config conf)
    {
        bool verdict = true;
        if(!ValidateDataPoints(conf.DataPoints))
            verdict = false;
        if(!ValidateMetaGlobal(conf.Meta))
            verdict = false;
        return verdict;
    }
    private static bool ValidateDataPoints(DataPoint[] dataPoints)
    {
        bool verdict = true;
        foreach (DataPoint dp in dataPoints)
        {
            if(!ValidateDataPoint(dp))
                verdict = false;
        }
        return verdict;
    }
    private static bool ValidateMetaGlobal(MetaGlobal metaGlobal)
    {
        Debug.Log("ValidateMetaGlobal: " +
            "X: " + metaGlobal.XLabelStart + metaGlobal.XLabelEnd + metaGlobal.XDescription +
            "Y: " + metaGlobal.YLabelStart + metaGlobal.YLabelEnd + metaGlobal.YDescription +
            "Z: " + metaGlobal.ZLabelStart + metaGlobal.ZLabelEnd + metaGlobal.ZDescription);
        return true;
    }

    private static bool ValidateDataPoint(DataPoint dataPoint)
    {
        bool verdict = true;
        if(!ValidateCoordinate(dataPoint.Coordinate))
            verdict = false;
        if(!ValidateMetaLocal(dataPoint.Meta))
            verdict = false;
        return verdict;
    }
    private static bool ValidateCoordinate(Vector3 coordinate)
    {
        Debug.Log("ValidateCoordinate: " + coordinate.x + " " + coordinate.y + " " + coordinate.z);
        return true;
    }
    private static bool ValidateMetaLocal(MetaLocal metaLocal)
    {
        Debug.Log("ValidateMetaLocal: " + metaLocal.Header + " " + metaLocal.Description);
        return true;
    }
}
