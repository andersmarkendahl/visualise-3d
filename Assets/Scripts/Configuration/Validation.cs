using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation
{
    private static void Log(string message)
    {
        Debug.LogError("WARN Validation error: " + message);
    }
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
            Log("DataPoints[] undefined");
            return false;
        }

        bool verdict = true;
        int i = 0;
        foreach (DataPoint dp in dataPoints)
        {
            if(!ValidateDataPoint(dp))
            {
                Log("DataPoints[" + i + "] failed to validate");
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
            Log("Meta undefined");
            return false;
        }

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelStart))
        {
            Log("Meta.XLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.XLabelEnd))
        {
            Log("Meta.XLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.XDescription))
        {
            Log("Meta.XDescription empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelStart))
        {
            Log("Meta.YLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YLabelEnd))
        {
            Log("Meta.YLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.YDescription))
        {
            Log("Meta.YDescription empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelStart))
        {
            Log("Meta.ZLabelStart empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZLabelEnd))
        {
            Log("Meta.ZLabelEnd empty or undefined");
            verdict = false;
        }
        if(string.IsNullOrWhiteSpace(metaGlobal.ZDescription))
        {
            Log("Meta.ZDescription empty or undefined");
            verdict = false;
        }

        return verdict;
    }

    private static bool ValidateDataPoint(DataPoint dataPoint)
    {
        if (dataPoint == null)
        {
            Log("DataPoint undefined");
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
            Log("Coordinate undefined");
            return false;
        }

        bool verdict = true;
        if (coordinate.x > 10.0f || coordinate.x < 0.0f)
        {
            Log("Coordinate x out of range: " + coordinate.x);
            verdict = false;
        }
        if (coordinate.y > 10.0f || coordinate.y < 0.0f)
        {
            Log("Coordinate y out of range: " + coordinate.y);
            verdict = false;
        }
        if (coordinate.z > 10.0f || coordinate.z < 0.0f)
        {
            Log("Coordinate z out of range: " + coordinate.z);
            verdict = false;
        }

        return verdict;
    }
    private static bool ValidateMetaLocal(MetaLocal metaLocal)
    {
        if (metaLocal == null)
        {
            Log("DataPoints[?].Meta undefined");
            return false;
        }

        bool verdict = true; 
        if(string.IsNullOrWhiteSpace(metaLocal.Header))
        {
            Log("DataPoints[?].Meta.Header Empty or Undefined");
            verdict = false;
        }
        
        return verdict;
    }
}
