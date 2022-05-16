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
        {
            Debug.LogError("DataPoints[] undefined");
            return false;
        }

        bool verdict = true;
        int i = 0;
        foreach (DataPoint dp in dataPoints)
        {
            if(!ValidateDataPoint(dp))
            {
                Debug.LogError("DataPoints[" + i + "] failed to validate");
                verdict = false;
            }
            i++;
        }
        return verdict;
    }
    private static bool ValidateMetaGlobal(MetaGlobal metaGlobal)
    {
        if (metaGlobal == null)
        {
            Debug.LogError("Meta undefined");
            return false;
        }

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelStart))
        {
            Debug.LogError("Meta.XLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelEnd))
        {
            Debug.LogError("Meta.XLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.XDescription))
        {
            Debug.LogError("Meta.XDescription empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelStart))
        {
            Debug.LogError("Meta.YLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelEnd))
        {
            Debug.LogError("Meta.YLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YDescription))
        {
            Debug.LogError("Meta.YDescription empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelStart))
        {
            Debug.LogError("Meta.ZLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelEnd))
        {
            Debug.LogError("Meta.ZLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZDescription))
        {
            Debug.LogError("Meta.ZDescription empty or undefined");
            verdict = false;
        }

        return verdict;
    }

    private static bool ValidateDataPoint(DataPoint dataPoint)
    {
        if (dataPoint == null)
        {
            Debug.LogError("DataPoint undefined");
            return false;
        }

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
        {
            Debug.LogError("Coordinate undefined");
            return false;
        }

        bool verdict = true;
        if (coordinate.x > 10.0f || coordinate.x < 0.0f)
        {
            Debug.LogError("Coordinate x out of range: " + coordinate.x);
            verdict = false;
        }
        if (coordinate.y > 10.0f || coordinate.y < 0.0f)
        {
            Debug.LogError("Coordinate y out of range: " + coordinate.y);
            verdict = false;
        }
        if (coordinate.z > 10.0f || coordinate.z < 0.0f)
        {
            Debug.LogError("Coordinate z out of range: " + coordinate.z);
            verdict = false;
        }

        return verdict;
    }
    private static bool ValidateMetaLocal(MetaLocal metaLocal)
    {
        if (metaLocal == null)
        {
            Debug.LogError("DataPoints[?].Meta undefined");
            return false;
        }

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaLocal.Header))
        {
            Debug.LogError("Header Empty or Undefined");
            verdict = false;
        }
        
        return verdict;
    }
}
