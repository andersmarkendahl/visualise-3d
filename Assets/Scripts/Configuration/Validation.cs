using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation
{
    public static bool Validate(Config conf)
    {
        if (conf == null)
            return false;

        bool verdict = true;
        if(!ValidateDataPoints(conf.DataPoints))
            verdict = false;
        if(!ValidateMetaGlobal(conf.Meta))
            verdict = false;
        return verdict;
    }
    private static bool ValidateDataPoints(DataPoint[] dataPoints)
    {
        if (dataPoints == null)
            return false;

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
        if (metaGlobal == null)
            return false;

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelStart))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelEnd))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.XDescription))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelStart))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelEnd))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.YDescription))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelStart))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelEnd))
            verdict = false;
        if(string.IsNullOrWhiteSpace(metaGlobal.ZDescription))
            verdict = false;

        return verdict;
    }

    private static bool ValidateDataPoint(DataPoint dataPoint)
    {
        if (dataPoint == null)
            return false;

        bool verdict = true;
        if(!ValidateCoordinate(dataPoint.Coordinate))
            verdict = false;
        if(!ValidateMetaLocal(dataPoint.Meta))
            verdict = false;
        return verdict;
    }
    private static bool ValidateCoordinate(Vector3 coordinate)
    {
        if (coordinate == null)
            return false;

        bool verdict = true;
        if (coordinate.x > 10.0f || coordinate.x < 0.0f)
            verdict = false;
        if (coordinate.y > 10.0f || coordinate.y < 0.0f)
            verdict = false;
        if (coordinate.z > 10.0f || coordinate.z < 0.0f)
            verdict = false;

        return verdict;
    }
    private static bool ValidateMetaLocal(MetaLocal metaLocal)
    {
        if (metaLocal == null)
            return false;

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaLocal.Header))
            verdict = false;

        return verdict;
    }
}
